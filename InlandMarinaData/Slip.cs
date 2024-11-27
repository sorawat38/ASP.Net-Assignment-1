namespace InlandMarinaData;
// *********************************************************************
// * Slip.cs
// *
// * Project: Assignment 1                             
// * Description: ASP.NET MVC Web Application for Inland Marina      
// * Version: 1.0.0                                        
// * Date: 2024-11-26                                      
// * Author: Sorawt (James) Tanthikun                
// * Purpose: Represents a Slip entity for the Inland Marina application, 
// *          including dimensions, associated dock, and leases.
// *********************************************************************
public class Slip
{
    /// <summary>
    /// Slip ID
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// Width of the slip (in feet).
    /// </summary>
    public int Width { get; set; }
    /// <summary>
    /// Length of the slip (in feet).
    /// </summary>
    public int Length { get; set; }
    /// <summary>
    /// Foreign key referencing the associated dock.
    /// </summary>
    public int DockID { get; set; }

    /// <summary>
    /// Navigation property representing the dock this slip belongs to
    /// </summary>
    public virtual Dock Dock { get; set; } 
    /// <summary>
    /// Navigation property representing the collection of leases associated with this slip.
    /// </summary>
    public virtual ICollection<Lease> Leases { get; set; }
}