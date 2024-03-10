
namespace Component.Domain.Models;

public abstract class Entity<T> : IEquatable<Entity<T>> where T: notnull
{
    public Id<T> Id { get; protected set; }

    protected Entity()
    {
    }

    protected Entity(Id<T> id)
    {
        Id = id;
    }

    public override bool Equals(object? obj) => obj is Entity<T> entity && Id.Equals(entity.Id);

    public static bool operator ==(Entity<T> left, Entity<T> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<T> left, Entity<T> right)
    {
        return !Equals(left, right);
    }

    public bool Equals(Entity<T>? other)
    {
        return Equals((object?)other);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}