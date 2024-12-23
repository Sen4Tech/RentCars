using System;
using RentCarsClient.Models.Input;
using RentCarsClient.Models.Output;

namespace RentCarsClient.Service;

public interface IRentCars
{
    Task<ApiResponse<IEnumerable<GetCarOutput>>> GetCar();

    Task<ApiResponse<GetCarOutput>> CreateCar(string id);

    Task<ApiResponse<string>> CreateRent(CreateCarInput request);

    Task<ApiResponse<string>> UpdateRent(string id, UpdateCarInput request);

    Task<ApiResponse<string>> DeleteCar(string id);
}
