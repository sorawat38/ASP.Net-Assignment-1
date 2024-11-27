using System.ComponentModel.DataAnnotations;

namespace InlandMarinaData;
// *********************************************************************
// * Dock.cs
// *
// * Project: Assignment 1                             
// * Description: ASP.NET MVC Web Application for Inland Marina      
// * Version: 1.0.0                                        
// * Date: 2024-11-26                                      
// * Author: Sorawat (James) Tanthikun                  
// * Purpose: Represents a Dock entity for the Inland Marina application.
// *********************************************************************

public class Dock
{    
    /// <summary>
    /// Dock ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Dock name
    /// </summary>
    [Required]
    [StringLength(30)]
    public string Name { get; set; }

    /// <summary>
    /// Indicates whether the dock has water service available.
    /// </summary>
    public bool WaterService { get; set; }
    
    /// <summary>
    /// Indicates whether the dock has electrical service available.
    /// </summary>
    public bool ElectricalService { get; set; }    
        
    /// <summary>
    /// Navigation property representing the collection of slips associated with this dock.
    /// </summary>
    public virtual ICollection<Slip> Slips { get; set; }
}