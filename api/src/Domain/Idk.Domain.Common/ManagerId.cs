namespace Idk.Domain.Common;

public class TenantId : IdentityBase {
   public TenantId(Guid id) : base(id) { }

   public static TenantId Of(Guid id) => new(id);
}