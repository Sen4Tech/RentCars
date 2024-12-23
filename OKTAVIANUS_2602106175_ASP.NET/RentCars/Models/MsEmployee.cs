using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCars.Models;

[Table("MsEmployee")] 
public class MsEmployee
{
    [Key]
    [StringLength(36)]
    public string Employee_id { get; set; }

    [StringLength(200)]
    public string name { get; set; }

    [StringLength(4000)] 
    [Column("[position]")]
    public string position { get; set; }

    [StringLength(200)]
    public string email { get; set; }

    [StringLength(36)]
    public string phone_number { get; set; }

    public ICollection<TrMaintenance> Maintenances {get; set;}

}
