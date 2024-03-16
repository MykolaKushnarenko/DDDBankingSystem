using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Component.Persistence.SqlServer.Conventions;

[SuppressMessage("Usage", "EF1001:Internal EF Core API usage.")]
public class EnumConvention : IEntityTypeAddedConvention
{
    private static readonly Inflector.Inflector Inflector = new(new CultureInfo("en-US"));

    public void ProcessEntityTypeAdded(IConventionEntityTypeBuilder entityTypeBuilder,
        IConventionContext<IConventionEntityTypeBuilder> context)
    {
        if (EnumTableHasAlreadyConfigured(entityTypeBuilder.Metadata.ClrType))
        {
            return;
        }

        entityTypeBuilder.Metadata
            .GetProperties()
            .Where(x => x.ClrType.IsEnum)
            .ToList()
            .ForEach(x => ConfigureEnumEntity(entityTypeBuilder, x));
    }

    private static bool EnumTableHasAlreadyConfigured(Type type) =>
        type.IsGenericType && type.GetGenericTypeDefinition() == typeof(EnumIdNameEntity<>);

    private static void ConfigureEnumEntity(
        IConventionEntityTypeBuilder entityTypeBuilder,
        IReadOnlyPropertyBase conventionEnumProperty)
    {
        var enumClrType = conventionEnumProperty.ClrType;
        var concreteType = typeof(EnumIdNameEntity<>).MakeGenericType(enumClrType);

        var enumIdNameEntityBuilder = entityTypeBuilder.ModelBuilder.Entity(concreteType)!;
        var internalEntityTypeBuilder = enumIdNameEntityBuilder as InternalEntityTypeBuilder ??
                                        throw new ArgumentNullException(nameof(enumIdNameEntityBuilder),
                                            "Could not cast to InternalEntityTypeBuilder");

        var conventionKeyPropertyBuilder = ConfigureEnumTable(enumIdNameEntityBuilder, enumClrType);

        SeedDataForEnumTable(enumClrType, concreteType, internalEntityTypeBuilder);

        var foreignKey = ConfigureRelationship(
            entityTypeBuilder as InternalEntityTypeBuilder, 
            conventionEnumProperty,
            enumIdNameEntityBuilder as InternalEntityTypeBuilder, conventionKeyPropertyBuilder);

        foreignKey.Builder.OnDelete(DeleteBehavior.NoAction, ConfigurationSource.Explicit);
    }

    private static IConventionPropertyBuilder ConfigureEnumTable(
        IConventionEntityTypeBuilder conventionEntityTypeBuilder,
        Type enumClrType)
    {
        conventionEntityTypeBuilder.ToTable(Inflector.Pluralize(enumClrType.Name));

        var conventionKeyPropertyBuilder = conventionEntityTypeBuilder
            .Property(enumClrType, nameof(EnumIdNameEntity<Enum>.Id))!;

        conventionEntityTypeBuilder
            .Property(typeof(string), nameof(EnumIdNameEntity<Enum>.Name))!
            .HasMaxLength(50);

        conventionEntityTypeBuilder.HasKey(new[] { conventionKeyPropertyBuilder.Metadata });
        return conventionKeyPropertyBuilder;
    }

    private static void SeedDataForEnumTable(
        Type enumClrType,
        Type genericType,
        InternalEntityTypeBuilder internalEntityTypeBuilder)
    {
        var data = Enum
            .GetValues(enumClrType)
            .Cast<object>()
            .Select(enumValue => Activator.CreateInstance(genericType, enumValue) ??
                                 throw new ArgumentNullException(nameof(enumValue),
                                     $"Could not create instance of {genericType} with enum value: {enumValue}"))
            .ToArray();

        internalEntityTypeBuilder.HasData(data, ConfigurationSource.Explicit);
    }

    private static ForeignKey ConfigureRelationship(
        InternalEntityTypeBuilder? entityTypeInternalBuilder,
        IReadOnlyPropertyBase conventionEnumProperty,
        InternalEntityTypeBuilder? enumIdNameEntityInternalBuilder,
        IConventionPropertyBuilder keyProperty)
    {
        ArgumentNullException.ThrowIfNull(entityTypeInternalBuilder);
        ArgumentNullException.ThrowIfNull(enumIdNameEntityInternalBuilder);

        var foreignKey = entityTypeInternalBuilder.HasRelationship(
                enumIdNameEntityInternalBuilder.Metadata,
                MemberIdentity.None.MemberInfo,
                ConfigurationSource.Explicit,
                targetIsPrincipal: null)!
            .Metadata;

        foreignKey.Builder.HasPrincipalKey(
            new[] { keyProperty.Metadata.GetIdentifyingMemberInfo() }!, ConfigurationSource.Explicit);

        foreignKey.Builder.HasForeignKey(
            new[] { conventionEnumProperty.Name }, entityTypeInternalBuilder.Metadata,
            ConfigurationSource.Explicit);

        return foreignKey;
    }

    private class EnumIdNameEntity<TEnum> where TEnum : Enum
    {
        public TEnum Id { get; set; }

        public string Name { get; set; }

        public EnumIdNameEntity(TEnum @enum)
        {
            Id = @enum;
            Name = @enum.ToString();
        }

        private EnumIdNameEntity()
        {
        }
    }
}