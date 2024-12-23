using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCars.Models.Result;

public class GetCarResultById
{
    public string car_id { get; set; }
    public string Model { get; set; }
    public string Name { get; set; }
    public string Transmission { get; set; }
    public int Number_of_car_seats { get; set; }
}
