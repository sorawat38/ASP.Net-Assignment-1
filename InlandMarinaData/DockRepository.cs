namespace InlandMarinaData;
// *********************************************************************
// * DockRepository.cs
// *
// * Project: Assignment 1                             
// * Description: ASP.NET MVC Web Application for Inland Marina      
// * Version: 1.0.0                                        
// * Date: 2024-11-26                                      
// * Author: Sorawat (James) Tanthikun                     
// * Purpose: Dock repository for Inland Marina MVC web application
//*********************************************************************
public class DockRepository
{
    /// <summary>
    /// Get a list of docks from the database.
    /// </summary>
    /// <param name="dbContext">Database context</param>
    /// <returns>List of docks</returns>
    public static List<Dock> GetDocks(InlandMarinaContext dbContext)
    {
        return dbContext.Docks
            .OrderBy(d => d.Name)
            .ToList();
    }
}