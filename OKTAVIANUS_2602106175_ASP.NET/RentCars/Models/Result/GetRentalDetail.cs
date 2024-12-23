using System;

namespace RentCars.Models.Result;

public class GetRentalDetail
{
     public DateTime rental_date { get; set; }

     public string name { get; set; }

     public DateTime return_date { get; set; }

     public bool payment_status { get; set; }

     public decimal total_price { get; set; }

      public decimal? price_per_day { get; set; }

      

}
