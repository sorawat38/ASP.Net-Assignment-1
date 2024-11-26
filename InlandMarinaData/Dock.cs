using System.ComponentModel.DataAnnotations;

namespace InlandMarinaData;

public class Dock
{    
    public int ID { get; set; }

    [Required]
    [StringLength(30)]
    public string Name { get; set; }

    public bool WaterService { get; set; }
    public bool ElectricalService { get; set; }    
        
    // navigation property
    public virtual ICollection<Slip> Slips { get; set; }
}