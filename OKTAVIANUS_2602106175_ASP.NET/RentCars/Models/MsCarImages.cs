using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCars.Models;

[Table("MsCarImages")] 
public class MsCarImages
{
    [Key]
    [StringLength(36)]
    public string Image_car_id { get; set; }

    [Required]
    [Url] // Memastikan format URL valid
    [StringLength(2000)]
    public string image_link { get; set; }

    [ForeignKey("Car_id")]
    public MsCar Car { get; set; }
    
    public string Car_id { get; set; }
}
