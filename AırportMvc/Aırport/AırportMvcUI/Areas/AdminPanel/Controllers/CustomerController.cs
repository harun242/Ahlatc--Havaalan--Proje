using AırportMvcUI.ApiServices;
using AırportMvcUI.ApiServices.NewFolder;
using AırportMvcUI.Areas.AdminPanel.Filters;
using AırportMvcUI.Areas.AdminPanel.Models.ApiTypes;
using AırportMvcUI.Areas.AdminPanel.Models.Dtos.Brand;
using AırportMvcUI.Areas.AdminPanel.Models.Dtos.Customer;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AırportMvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class CustomerController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;
        public CustomerController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {
            var response =
                  await _apiService.GetData<ResponseBody<List<CustomerItem>>>("/Customers");

            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Save(NewCustomerDto dto)
        {

            // servisle haberleşip kategori bilgisini kaydedilmesini sağlayacağız

            var postData = new
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                Address = dto.Address,

            };

            var response =
              await _apiService.PostData<ResponseBody<CustomerItem>>("/Customers", JsonSerializer.Serialize(postData));

            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Müşteri Bilgileri Başarıyla Kaydedildi" });

            if (response.ErrorMessages == null)
                return Json(new { IsSuccess = true, Message = "Müşteri Bilgileri Başarıyla Kaydedildi" });

            var errorMessages = string.Empty;
            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Müşteri Bilgileri Kaydedilemedi <br /> {errorMessages}"
            });


        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response =
              await _apiService.DeleteData($"/Customers/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Müşteri Bilgisi Silindi" });

            return Json(new { IsSuccess = false, Message = "Müşteri Bilgisi  Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var response =
              await _apiService.GetData<ResponseBody<CustomerItem>>($"/Customers/{id}");

            return Json(new 
            {
                Name = response.Data.Name,
                Surname = response.Data.Surname,
                Email = response.Data.Email,
                Address = response.Data.Address,
                CustomerID = response.Data.CustomerID       
            });

        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateCustomerDto dto)
        {

            // servisle haberleşip kategori bilgisini kaydedilmesini sağlayacağız

            var postData = new
            {
                CustomerID = dto.CustomerID,
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                Address = dto.Address,

            };

            var response =
              await _apiService.PutData<ResponseBody<NoData>>("/Customers", JsonSerializer.Serialize(postData));

            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Müşteri Bilgileri Başarıyla Kaydedildi" });

            if (response.ErrorMessages == null)
                return Json(new { IsSuccess = true, Message = "Müşteri Bilgileri Başarıyla Kaydedildi" });

            var errorMessages = string.Empty;
            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Müşteri Bilgileri Kaydedilemedi <br /> {errorMessages}"
            });


        }


    }
}
