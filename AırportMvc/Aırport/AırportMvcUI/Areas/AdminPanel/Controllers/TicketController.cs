using AırportMvcUI.ApiServices;
using AırportMvcUI.Areas.AdminPanel.Filters;
using AırportMvcUI.Areas.AdminPanel.Models.ApiTypes;
using AırportMvcUI.Areas.AdminPanel.Models.Dtos.Ticket;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AırportMvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class TicketController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;
        public TicketController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {
            var response =
        await _apiService.GetData<ResponseBody<List<TicketItem>>>("/Tickets");

            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Save(NewTicketDto dto)
        {

            // servisle haberleşip kategori bilgisini kaydedilmesini sağlayacağız

            var postData = new
            {
                PassengerID = dto.PassengerID,
                SeatNumber = dto.SeatNumber,
                PassengerName = dto.PassengerName,
                PassengerSurname = dto.PassengerSurname,
                Fee = dto.Fee,
                BoardingCity = dto.BoardingCity,
                LandedCity = dto.LandedCity,

            };
           
        var response =
              await _apiService.PostData<ResponseBody<TicketItem>>("/Tickets", JsonSerializer.Serialize(postData));

            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Bilet Bilgileri Başarıyla Kaydedildi" });

            if (response.ErrorMessages == null)
                return Json(new { IsSuccess = true, Message = "Bilet Bilgileri Başarıyla Kaydedildi" });

            var errorMessages = string.Empty;
            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Bilet Bilgileri Kaydedilemedi <br /> {errorMessages}"
            });


        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response =
              await _apiService.DeleteData($"/Tickets/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Bilet Bilgisi Silindi" });

            return Json(new { IsSuccess = false, Message = "Bilet Bilgisi  Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetTicket(int id)
        {
            var response =
              await _apiService.GetData<ResponseBody<TicketItem>>($"/Tickets/{id}");

            return Json(new
            {
                PassengerID = response.Data.PassengerID,
                SeatNumber = response.Data.SeatNumber,
                PassengerName = response.Data.PassengerName,
                PassengerSurname = response.Data.PassengerSurname,
                Fee = response.Data.Fee,
                BoardingCity = response.Data.BoardingCity,
                LandedCity = response.Data.LandedCity,
                TıcketID = response.Data.TıcketID,
            });

        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateTicketDto dto)
        {

            // servisle haberleşip kategori bilgisini kaydedilmesini sağlayacağız

            var postData = new
            {
                PassengerID = dto.PassengerID,
                SeatNumber = dto.SeatNumber,
                PassengerName = dto.PassengerName,
                PassengerSurname = dto.PassengerSurname,
                Fee = dto.Fee,
                BoardingCity = dto.BoardingCity,
                LandedCity = dto.LandedCity,

            };

            var response =
                  await _apiService.PutData<ResponseBody<TicketItem>>("/Tickets", JsonSerializer.Serialize(postData));

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Bilet Bilgileri Başarıyla Kaydedildi" });

            if (response.ErrorMessages == null)
                return Json(new { IsSuccess = true, Message = "Bilet Bilgileri Başarıyla Kaydedildi" });

            var errorMessages = string.Empty;
            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Bilet Bilgileri Kaydedilemedi <br /> {errorMessages}"
            });


        }
    }
}
