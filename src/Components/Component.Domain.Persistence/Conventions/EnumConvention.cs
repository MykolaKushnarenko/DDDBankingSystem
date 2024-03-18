using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
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
    private const string Scheme = "Lookup";

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
            .ForEach(property => ConfigureEnumEntity(entityTypeBuilder, property));
    }

    private static void ConfigureEnumEntity(
        IConventionEntityTypeBuilder entityTypeBuilder,
        IReadOnlyPropertyBase conventionEnumProperty)
    {
        var enumPropertyType = conventionEnumProperty.ClrType;
        var concreteType = typeof(EnumIdNameEntity<>).MakeGenericType(enumPropertyType);

        if (entityTypeBuilder.ModelBuilder is not InternalModelBuilder internalModelBuilder)
        {
            throw new ArgumentNullException(
                nameof(entityTypeBuilder.ModelBuilder),
                "Could not cast 'entityTypeBuilder.ModelBuilder' to 'InternalModelBuilder'.");
        }

        var internalTypeEntityBuilder = internalModelBuilder.Entity(concreteType, ConfigurationSource.Explicit,
            shouldBeOwned: false)!;

        ConfigureEnumTable(internalTypeEntityBuilder, enumPropertyType, concreteType);
        ConfigureRelationship(entityTypeBuilder, concreteType, enumPropertyType);
    }

    private static void ConfigureRelationship(IConventionEntityTypeBuilder entityTypeBuilder, Type concreteType,
        MemberInfo navigationalMemberInfo)
    {
        var entityBuilder = new EntityTypeBuilder((EntityType)entityTypeBuilder.Metadata);

        entityBuilder.HasOne(concreteType)
            .WithMany()
            .HasPrincipalKey(nameof(EnumIdNameEntity<Enum>.Id))
            .HasForeignKey(navigationalMemberInfo.Name)
            .OnDelete(DeleteBehavior.NoAction);
    }

    private static void ConfigureEnumTable(InternalEntityTypeBuilder internalTypeEntityBuilder,
        Type enumPropertyClrType,
        Type concreteType)
    {
        var entityBuilder = new EntityTypeBuilder(internalTypeEntityBuilder.Metadata);

        entityBuilder.ToTable(Inflector.Pluralize(enumPropertyClrType.Name), Scheme);

        entityBuilder.Property(enumPropertyClrType, nameof(EnumIdNameEntity<Enum>.Id));
        entityBuilder.Property(typeof(string), nameof(EnumIdNameEntity<Enum>.Name)).HasMaxLength(50);

        entityBuilder.HasKey(nameof(EnumIdNameEntity<Enum>.Id));

        SeedDataForEnumTable(entityBuilder, enumPropertyClrType, concreteType);
    }

    private static void SeedDataForEnumTable(
        EntityTypeBuilder entityTypeBuilder,
        Type enumClrType,
        Type concreteType)
    {
        var data = Enum
            .GetValues(enumClrType)
            .Cast<object>()
            .Select(enumValue => Activator.CreateInstance(concreteType, enumValue) ??
                                 throw new ArgumentNullException(nameof(enumValue),
                                     $"Could not create instance of {concreteType} with enum value: {enumValue}"))
            .ToArray();

        entityTypeBuilder.HasData(data);
    }

    private static bool EnumTableHasAlreadyConfigured(Type type) =>
        type.IsGenericType && type.GetGenericTypeDefinition() == typeof(EnumIdNameEntity<>);

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