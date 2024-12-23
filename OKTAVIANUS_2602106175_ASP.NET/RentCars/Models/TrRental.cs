using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCars.Models;

[Table("TrRental")] 
public class TrRental
{
    [Key]
    [StringLength(36)]
    public string Rental_id { get; set; }

    public DateTime rental_date { get; set; }

    public DateTime return_date { get; set; }

    public decimal total_price { get; set; }

    public bool payment_status { get; set; }

    // Foreign key
    public string Customer_id { get; set; }
    
    [ForeignKey("Customer_id")]
    public MsCustomer Customer { get; set; }
    
    public string Car_id { get; set; }
    
    [ForeignKey("Car_id")]
    public MsCar Car { get; set; }

    public ICollection<TrPayment> Payments { get; set; }
}

