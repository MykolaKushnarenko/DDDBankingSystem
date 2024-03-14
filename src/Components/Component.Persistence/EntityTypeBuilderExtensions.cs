using System.Linq.Expressions;
using Component.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Component.Persistence;

public static class EntityTypeBuilderExtensions
{
    public static PropertyBuilder<Id<TProperty>> HasId<TEntity, TProperty>(this EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, Id<TProperty>>> propertyId) where TEntity : class
    {
        return builder
            .Property(propertyId)
            .HasConversion(
                idObj => idObj.Value,
                idValue => new Id<TProperty>(idValue));
    }

    public static PropertyBuilder<Id<TProperty>> HasId<TEntityParent, TEntityChild, TProperty>(
        this OwnedNavigationBuilder<TEntityParent, TEntityChild> builder,
        Expression<Func<TEntityChild, Id<TProperty>>> propertyId) where TEntityParent : class where TEntityChild : class
    {
        return builder
            .Property(propertyId)
            .HasConversion(
                idObj => idObj.Value,
                idValue => new Id<TProperty>(idValue));
    }

    public static OwnershipBuilder<TEntityParent, TEntityChild> HasForeignKey<TEntityParent, TEntityChild>(
        this OwnedNavigationBuilder<TEntityParent, TEntityChild> builder)
        where TEntityParent : class where TEntityChild : class
    {
        var foreignKeyPropertyNames =
            builder.Metadata.PrincipalEntityType.FindPrimaryKey()!
                .Properties
                .Select(x => x.Name)
                .ToArray();

        return builder.WithOwner().HasForeignKey(foreignKeyPropertyNames);
    }
}