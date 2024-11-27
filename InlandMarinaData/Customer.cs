using System.ComponentModel.DataAnnotations;

namespace InlandMarinaData;
// *********************************************************************
// * Customer.cs
// *
// * Project: Assignment 1                             
// * Description: ASP.NET MVC Web Application for Inland Marina      
// * Version: 1.0.0                                        
// * Date: 2024-11-26                                      
// * Author: Sorawat (James) Tanthikun                   
// * Purpose: Represents a Customer entity for the Inland Marina application.
// *********************************************************************

public class Customer
{
    /// <summary>
    /// Customer ID
    /// </summary>
    public int ID { get; set; }
    
    /// <summary>
    /// Customer first name
    /// </summary>
    [Required]
    [StringLength(30)]
    public string FirstName { get; set; } 

    /// <summary>
    /// Customer last name
    /// </summary>
    [Required]
    [StringLength(30)]
    public string LastName { get; set; }

    /// <summary>
    /// Customer phone number
    /// </summary>
    [Required]
    [StringLength(15)]
    public string Phone { get; set; }

    /// <summary>
    /// Customer city
    /// </summary>
    [Required]
    [StringLength(30)]
    public string City { get; set; }

    // navigation property
    /// <summary>
    /// Navigation property representing the collection of leases associated with this customer.
    /// </summary>
    public virtual ICollection<Lease> Leases { get; set; }
}