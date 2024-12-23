using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RentCars.Models;

[Table("TrMaintenance")] 
public class TrMaintenance
{
    [Key]
    [StringLength(36)]
    public string TrMaintenance_id { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime maintenance_date { get; set; }

    [StringLength(4000)]
    public string description { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal cost { get; set; }

    [ForeignKey("Car_id")]
    public MsCar Car { get; set; }
    public string Car_id { get; set; }

    [ForeignKey("MsEmployee")]
    public MsEmployee Employee { get; set; }
    public string Employee_id { get; set; }
}
