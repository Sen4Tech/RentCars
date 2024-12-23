using System;

namespace RentCars.Models.Request;

public class CreateCarRequest
{
    public string Rental_id { get; set; }

    public DateTime Rental_date { get; set; }

    public DateTime Return_date { get; set; }

    public int Year { get; set; }

    public string image_link { get; set; }
}
