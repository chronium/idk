namespace Idk.Domain.Common;

public class UserId : IdentityBase {
   protected UserId(Guid id) : base(id) { }

   public static UserId Of(Guid id) => new(id);
}
