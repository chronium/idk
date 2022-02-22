namespace Idk.Domain.Common.Models;

/// <summary>
/// https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
/// </summary>
public abstract class ValueObjectBase {
   protected abstract IEnumerable<object> GetEqualityComponents();

   public override bool Equals(object? obj) {
      if (ReferenceEquals(this, obj))
         return true;

      if (obj is null)
         return false;

      if (GetType() != obj.GetType())
         return false;

      var valueObject = (ValueObjectBase)obj;

      return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
   }

   public override int GetHashCode() =>
       GetEqualityComponents().Aggregate(1, (current, obj) => {
          unchecked {
             return current * 23 + (obj?.GetHashCode() ?? 0);
          }
       });

   public static bool operator ==(ValueObjectBase object1, ValueObjectBase object2) 
      => object1 is null && object2 is null || (object1 is not null && object2 is not null && object1.Equals(object2));

   public static bool operator !=(ValueObjectBase object1, ValueObjectBase object2)
       => !(object1 == object2);
}
