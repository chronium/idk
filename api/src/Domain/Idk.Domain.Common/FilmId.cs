namespace Idk.Domain.Common;

public class FilmId : IdentityBase {
   protected FilmId(Guid id) : base(id) { }

   public static FilmId Of(Guid id) => new(id);
}
