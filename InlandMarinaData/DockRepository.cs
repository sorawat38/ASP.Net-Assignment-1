namespace InlandMarinaData;

public class DockRepository
{
    public static List<Dock> GetDocks(InlandMarinaContext dbContext)
    {
        return dbContext.Docks
            .OrderBy(d => d.Name)
            .ToList();
    }
}