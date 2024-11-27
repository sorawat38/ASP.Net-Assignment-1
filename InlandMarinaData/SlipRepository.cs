using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace InlandMarinaData;
// *********************************************************************
// * SlipRepository.cs
// *
// * Project: Assignment 1                             
// * Description: ASP.NET MVC Web Application for Inland Marina      
// * Version: 1.0.0                                        
// * Date: 2024-11-26                                      
// * Author: Sorawat (James) Tanthikun                     
// * Purpose: Slip repository for Inland Marina MVC web application
//*********************************************************************
public class SlipRepository
{
    /// <summary>
    /// Gets a list of unleased slips from the database.
    /// </summary>
    /// <param name="dbContext">The database context to query.</param>
    /// <returns>A list of unleased slips.</returns>
    public static List<Slip> GetUnleasedSlips(InlandMarinaContext dbContext)
    {
        var unleasedSlips = dbContext.Slips
            .GroupJoin(
                dbContext.Leases,
                slip => slip.ID,
                lease => lease.SlipID,
                (slip, slipLeases) => new { slip, slipLeases }
            )
            .SelectMany(
                s => s.slipLeases.DefaultIfEmpty(),
                (s, lease) => new { s.slip, lease }
            )
            .Where(s => s.lease == null)
            .Select(s => s.slip)
            .Include(s => s.Dock)
            .ToList();

        return unleasedSlips;
    }
    
    /// <summary>
    /// Get slips by dock.
    /// </summary>
    /// <param name="dbContext">Database context</param>
    /// <param name="dockId">Dock Id</param>
    /// <returns>List of slips</returns>
    public static List<Slip> GetSlipsByDock(InlandMarinaContext dbContext, int dockId)
    {
        List<Slip> slips = dbContext.Slips
            .Where(s => s.DockID == dockId)
            .Include(s => s.Dock)
            .ToList();

        return slips;
    }
}