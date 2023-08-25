using AırportMvcUI.ApiServices;
using AırportMvcUI.Areas.AdminPanel.Filters;
using AırportMvcUI.Areas.AdminPanel.Models.ApiTypes;
using AırportMvcUI.Areas.AdminPanel.Models.Dtos.Flight;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AırportMvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class FlightController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;
        public FlightController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetData<ResponseBody<List<FlightItem>>>("/Flights");

            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Save(NewFlightDto dto)
        {

            // servisle haberleşip kategori bilgisini kaydedilmesini sağlayacağız

            var postData = new
            {
                DepartureCity = dto.DepartureCity,
                LandingCity = dto.LandingCity,
              
            };

            var response =
              await _apiService.PostData<ResponseBody<FlightItem>>("/Flights", JsonSerializer.Serialize(postData));

            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Uçuş Bilgileri Başarıyla Kaydedildi" });

            if (response.ErrorMessages == null)
                return Json(new { IsSuccess = true, Message = "Uçuş Bilgileri Başarıyla Kaydedildi" });

            var errorMessages = string.Empty;
            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Uçuş Bilgileri Kaydedilemedi <br /> {errorMessages}"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response =
              await _apiService.DeleteData($"/Flights/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Uçuş Bilgisi Silindi" });

            return Json(new { IsSuccess = false, Message = "Uçuş Bilgisi  Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetFlight(int id)
        {
            var response =
              await _apiService.GetData<ResponseBody<FlightItem>>($"/Flights/{id}");

            return Json(new
            {
                DepartureCity = response.Data.DepartureCity,
                LandingCity = response.Data.LandingCity,
                RouteID = response.Data.RouteID,
            });

        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateFlightDto dto)
        {

            // servisle haberleşip kategori bilgisini kaydedilmesini sağlayacağız

            var postData = new
            {
                DepartureCity = dto.DepartureCity,
                LandingCity = dto.LandingCity,

            };

            var response =
              await _apiService.PutData<ResponseBody<FlightItem>>("/Flights", JsonSerializer.Serialize(postData));

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Uçuş Bilgileri Başarıyla Kaydedildi" });

            if (response.ErrorMessages == null)
                return Json(new { IsSuccess = true, Message = "Uçuş Bilgileri Başarıyla Kaydedildi" });

            var errorMessages = string.Empty;
            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Uçuş Bilgileri Kaydedilemedi <br /> {errorMessages}"
            });
        }
    }
}
