namespace Idk.Domain.Tenant;

public class User {
   [Required]
   [MaxLength(128)]
   public string Name { get; set; } = default!;

   public static User Of(DbUser dbUser)
      => new() {
         Name = dbUser.Name,
      };

   public static User? Maybe(DbUser? dbUser)
      => dbUser is null ? null : Of(dbUser);
}
