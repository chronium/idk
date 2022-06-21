namespace Idk.Domain.Common;

public class TitleId : IdentityBase {
   protected TitleId(Guid id) : base(id) { }

   public static TitleId Of(Guid id) => new(id);
}
