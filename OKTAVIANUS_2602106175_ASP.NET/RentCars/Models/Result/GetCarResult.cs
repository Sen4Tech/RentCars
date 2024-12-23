using System;

namespace RentCars.Models.Result;

public class GetCarResult
{
     public string Car_id { get; set; }
     public string name { get; set; }
    public decimal? price_per_day { get; set; }
    public int year { get; set; }
    public string image_link { get; set; }

    public DateTime rental_date { get; set; }

    public DateTime return_date { get; set; }

    
}

