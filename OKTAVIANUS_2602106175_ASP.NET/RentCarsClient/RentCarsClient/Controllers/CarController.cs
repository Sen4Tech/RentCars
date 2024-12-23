using Microsoft.AspNetCore.Mvc;
using RentCarsClient.Models.Input;
using RentCarsClient.Service;

namespace RentCarsClient.Controllers
{
    public class CarController : Controller
    {
        private readonly IRentCars _CarApi;
        // GET: CarController

        public  CarController(IRentCars carApi)
        {
            _CarApi = carApi;
        }
        public ActionResult Index()
        {
            return View();
        }

      public async Task<IActionResult> GetCar()
        {
            var result = await _CarApi.GetCar();
            return Json(result);
        }
        public async Task<IActionResult> CreateCar(string id)
        {
            var result = await _CarApi.CreateCar(id);
            return Json(result);
        }
        public async Task<IActionResult> CreateRent([FromBody] CreateCarInput request)
        {
            var result = await _CarApi.CreateRent(request);
            return Json(result);
        }
        public async Task<IActionResult> UpdateRent(string id, [FromBody] UpdateCarInput request)
        {
            var result = await _CarApi.UpdateRent(id, request);
            return Json(result);
        }
        public async Task<IActionResult> DeleteCar(string id)
        {
            var result = await _CarApi.DeleteCar(id);
            return Json(result);
        }


    }
}
