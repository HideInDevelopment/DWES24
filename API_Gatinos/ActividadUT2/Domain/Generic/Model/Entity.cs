namespace ActividadUT2.Domain.Generic;

public class Entity<TKey>
{
    public TKey Id { get; set; }
    public bool IsTransient => Id.Equals(default(TKey));

    public override bool Equals(object obj) =>
        obj is Entity<TKey> item
        && !item.IsTransient
        && !IsTransient
        && (ReferenceEquals(this, item) || Id.Equals(item.Id));

    public static bool operator ==(Entity<TKey> left, Entity<TKey> right) =>
        ReferenceEquals(left, right) || !(left is null) && left.Equals(right);

    public static bool operator !=(Entity<TKey> left, Entity<TKey> right) => !(left == right);

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}