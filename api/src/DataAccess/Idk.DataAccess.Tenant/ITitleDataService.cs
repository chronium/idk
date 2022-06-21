namespace Idk.DataAccess.Tenant;

public interface ITitleDataService {
   public IEnumerable<Title> GetAll();
   public Title? GetById(Guid id);

   public Title InsertSave(string Name, string Image, int Kind, DateOnly StartDate, DateOnly? EndDate);
}
