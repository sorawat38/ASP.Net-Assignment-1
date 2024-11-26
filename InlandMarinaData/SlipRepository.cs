using Microsoft.Identity.Client;

namespace InlandMarinaData;

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
            .ToList();

        return unleasedSlips;
    }
}