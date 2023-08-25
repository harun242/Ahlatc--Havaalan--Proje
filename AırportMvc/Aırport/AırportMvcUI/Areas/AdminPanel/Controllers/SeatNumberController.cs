using AırportMvcUI.ApiServices;
using AırportMvcUI.Areas.AdminPanel.Filters;
using AırportMvcUI.Areas.AdminPanel.Models.ApiTypes;
using AırportMvcUI.Areas.AdminPanel.Models.Dtos.SeatNumber;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AırportMvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class SeatNumberController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;
        public SeatNumberController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {
            var response =
        await _apiService.GetData<ResponseBody<List<SeatNumberItem>>>("/SeatsNumbers");

            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Save(NewSeatNumberDto dto)
        {

            // servisle haberleşip kategori bilgisini kaydedilmesini sağlayacağız

            var postData = new
            {
                BoardingCity = dto.BoardingCity,
                LandedCity = dto.LandedCity,
                TicketNumber = dto.TicketNumber,

            };

            var response =
              await _apiService.PostData<ResponseBody<SeatNumberItem>>("/SeatsNumbers", JsonSerializer.Serialize(postData));

            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Koltuk Numara Bilgileri Başarıyla Kaydedildi" });

            if (response.ErrorMessages == null)
                return Json(new { IsSuccess = true, Message = "Koltuk Numara Bilgileri Başarıyla Kaydedildi" });

            var errorMessages = string.Empty;
            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Koltuk Numara Bilgileri Kaydedilemedi <br /> {errorMessages}"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response =
              await _apiService.DeleteData($"/SeatsNumbers/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Koltuk Numara Bilgisi Silindi" });

            return Json(new { IsSuccess = false, Message = "Koltuk Numara Bilgisi  Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetSeatNumber(int id)
        {
            var response =
              await _apiService.GetData<ResponseBody<SeatNumberItem>>($"/SeatsNumbers/{id}");

            return Json(new SeatNumberItem
            {
                BoardingCity = response.Data.BoardingCity,
                LandedCity = response.Data.LandedCity,
                TicketNumber = response.Data.TicketNumber,
                ExpeditionID = response.Data.ExpeditionID,            
            });

        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateSeatNumberDto dto)
        {

            // servisle haberleşip kategori bilgisini kaydedilmesini sağlayacağız

            var postData = new
            {
                BoardingCity = dto.BoardingCity,
                LandedCity = dto.LandedCity,
                TicketNumber = dto.TicketNumber,

            };

            var response =
              await _apiService.PutData<ResponseBody<SeatNumberItem>>("/SeatsNumbers", JsonSerializer.Serialize(postData));

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Koltuk Numara Bilgileri Başarıyla Kaydedildi" });

            if (response.ErrorMessages == null)
                return Json(new { IsSuccess = true, Message = "Koltuk Numara Bilgileri Başarıyla Kaydedildi" });

            var errorMessages = string.Empty;
            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Koltuk Numara Bilgileri Kaydedilemedi <br /> {errorMessages}"
            });
        }
    }
}

