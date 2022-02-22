namespace Idk.Domain.Common.Models;

public class IdentityBase : ValueObjectBase {
   public Guid Id { get; set; }

   protected IdentityBase(Guid id)
      => Id = id;

   protected override IEnumerable<object> GetEqualityComponents() {
      yield return Id;
   }

   public override string ToString() => $"{GetType().Name}:{Id}";

   public static implicit operator Guid(IdentityBase id) => id.Id;
}
