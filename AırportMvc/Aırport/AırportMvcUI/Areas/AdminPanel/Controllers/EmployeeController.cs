using AırportMvcUI.ApiServices;
using AırportMvcUI.Areas.AdminPanel.Filters;
using AırportMvcUI.Areas.AdminPanel.Models.ApiTypes;
using AırportMvcUI.Areas.AdminPanel.Models.Dtos.Employee;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AırportMvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class EmployeeController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;
        public EmployeeController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {
            var response =
        await _apiService.GetData<ResponseBody<List<EmployeeItem>>>("/Employees");

            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Save(NewEmployeeDto dto)
        {

            // servisle haberleşip kategori bilgisini kaydedilmesini sağlayacağız

            var postData = new
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                
            };

            var response =
              await _apiService.PostData<ResponseBody<EmployeeItem>>("/Employees", JsonSerializer.Serialize(postData));

            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Çalışan Bilgileri Başarıyla Kaydedildi" });

            if (response.ErrorMessages == null)
                return Json(new { IsSuccess = true, Message = "Çalışan Bilgileri Başarıyla Kaydedildi" });

            var errorMessages = string.Empty;
            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Çalışan Bilgileri Kaydedilemedi <br /> {errorMessages}"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response =
              await _apiService.DeleteData($"/Employees/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Çalışan Bilgisi Silindi" });

            return Json(new { IsSuccess = false, Message = "Çalışan Bilgisi  Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var response =
              await _apiService.GetData<ResponseBody<EmployeeItem>>($"/Employees/{id}");

            return Json(new 
            {
                Name = response.Data.Name,
                Surname = response.Data.Surname,
                Email = response.Data.Email,
                EmployeeID = response.Data.EmployeeID,
            });

        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateEmployeeDto dto)
        {

            // servisle haberleşip kategori bilgisini kaydedilmesini sağlayacağız

            var postData = new
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,

            };

            var response =
              await _apiService.PutData<ResponseBody<EmployeeItem>>("/Employees", JsonSerializer.Serialize(postData));

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Çalışan Bilgileri Başarıyla Kaydedildi" });

            if (response.ErrorMessages == null)
                return Json(new { IsSuccess = true, Message = "Çalışan Bilgileri Başarıyla Kaydedildi" });

            var errorMessages = string.Empty;
            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Çalışan Bilgileri Kaydedilemedi <br /> {errorMessages}"
            });
        }
    }
}

