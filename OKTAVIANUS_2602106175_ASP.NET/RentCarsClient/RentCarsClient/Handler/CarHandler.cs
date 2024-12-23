using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using RentCarsClient.Models.Input;
using RentCarsClient.Models.Output;
using RentCarsClient.Service;

namespace RentCarsClient.Handler;

public class CarHandler : IRentCars
{
    private readonly IConfiguration _configuration;
    private readonly string baseUrl = "";

    private HttpClient HttpClient = new HttpClient();

    public CarHandler(IConfiguration configuration)
    {
        _configuration = configuration;
        baseUrl = _configuration["apiEndpoint"];
    }

    public async Task<ApiResponse<IEnumerable<GetCarOutput>>> GetCar()
    {
        string endpoint = baseUrl + "/Car";

        var rentOutput = new ApiResponse<IEnumerable<GetCarOutput>>();

        var response = await HttpClient.GetAsync(endpoint);

        string ApiResponse = await response.Content.ReadAsStringAsync();

        if(!string.IsNullOrEmpty(ApiResponse))
        {
            rentOutput = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<GetCarOutput>>>(ApiResponse);
        }

        return rentOutput;
    }

    public async Task<ApiResponse<GetCarOutput>> CreateCar(string id){
        string endpoint = baseUrl + "Car/" + id;

        var carOutput = new ApiResponse<GetCarOutput>();

        var response = await HttpClient.GetAsync(endpoint);
        string apiResponse = await response.Content.ReadAsStringAsync();

        if (!string.IsNullOrEmpty(apiResponse))
        {
            carOutput = JsonConvert.DeserializeObject<ApiResponse<GetCarOutput>>(apiResponse);
        }

        return carOutput;
    }
    
    public async Task<ApiResponse<string>> CreateRent(CreateCarInput request){
        if (request == null)
        {
            return new ApiResponse<string>
            {
                StatusCode = 400,
                Data = "Bad Request"
            };
        }

        string endpoint = baseUrl + "Car";
        var response = await HttpClient.PostAsJsonAsync(endpoint, request);
        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();

        return apiResponse;
    }
    public async Task<ApiResponse<string>> UpdateRent(string id, UpdateCarInput request){
        if (id == null || request == null)
        {
            return new ApiResponse<string>
            {
                StatusCode = 400,
                Data = "Bad Request"
            };
        }

        string endpoint = baseUrl + "Car/" + id;
        var response = await HttpClient.PutAsJsonAsync(endpoint, request);
        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();

        return apiResponse;
    }
    
    public async Task<ApiResponse<string>> DeleteCar(string id){
        if (id == null)
        {
            return new ApiResponse<string>
            {
                StatusCode = 400,
                Data = "Bad Request"
            };
        }

        string endpoint = baseUrl + "Car/" + id;
        var response = await HttpClient.DeleteAsync(endpoint);
        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();

        return apiResponse;
    }

}
