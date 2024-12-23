using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCars.Models;

[Table("MsCustomer")] 
public class MsCustomer
{
    [Key]
    [StringLength(36)]
    public string Customer_id { get; set; }

    [StringLength(100)]
    public string email { get; set; }

    [StringLength(100)]
    public string password { get; set; }

    [StringLength(200)]
    public string name { get; set; }

    [StringLength(50)]
    public string phone_number { get; set; }

    [StringLength(500)]
    public string address { get; set; }

    [StringLength(100)]
    public string driver_license_number { get; set; }

    public ICollection<TrRental> Rentals {get; set;}

}
