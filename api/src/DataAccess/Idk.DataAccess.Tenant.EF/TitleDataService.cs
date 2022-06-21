namespace Idk.DataAccess.Tenant.EF;

public class TitleDataService : ITitleDataService {
   private readonly TenantContext context;

   public TitleDataService(TenantContext context) => this.context = context;

   public IEnumerable<Title> GetAll()
      => context.Titles.AsQueryable().Select(Title.Of);

   public Title? GetById(Guid id)
      => Title.Maybe(context.Titles.SingleOrDefault(t => t.Id == id));

   public Title InsertSave(string Name, string Image, int Kind, DateOnly StartDate, DateOnly? EndDate) {
      var entity = context.Titles.Add(new DbTitle {
         Name = Name,
         Image = Image,
         Kind = (DbTitle.TitleKind)Kind,
         StartDate = StartDate,
         EndDate = EndDate
      }).Entity;
      context.SaveChanges();
      
      return Title.Of(entity);
   }
}
