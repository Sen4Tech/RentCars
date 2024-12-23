using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCars.Models;

[Table("TrPayment")] 
public class TrPayment
{
    [Key]
    [StringLength(36)]
    public string Payment_id { get; set; }

    [Required(ErrorMessage = "Payment date is required")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime payment_date { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal amount { get; set; }

    [Required]
    public string payment_method { get; set; }

    [ForeignKey("Rental_id")]
    [StringLength(36)]
    public string Rental_id { get; set; }
    public TrRental Rental { get; set; }
}