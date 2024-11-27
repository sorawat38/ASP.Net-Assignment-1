namespace InlandMarinaData;

// *********************************************************************
// * Lease.cs
// *
// * Project: Assignment 1                             
// * Description: ASP.NET MVC Web Application for Inland Marina      
// * Version: 1.0.0                                        
// * Date: 2024-11-26                                      
// * Author: Sorawat (James) Tanthikun                
// * Purpose: Represents a Lease entity for the Inland Marina application.
// *********************************************************************
public class Lease
{
    /// <summary>
    /// Lease ID
    /// </summary>
    public int ID { get; set; }
    
    /// <summary>
    /// Foreign key for Slip
    /// </summary>
    public int SlipID { get; set; }
    /// <summary>
    /// Foreign key for Customer
    /// </summary>
    public int CustomerID { get; set; }
    
    /// <summary>
    /// Navigation property representing the customer who leased the slip.
    /// </summary>
    public virtual Customer Customer { get; set; }
    /// <summary>
    /// Navigation property representing the slip that has been leased.
    /// </summary>
    public virtual Slip Slip { get; set; }
}