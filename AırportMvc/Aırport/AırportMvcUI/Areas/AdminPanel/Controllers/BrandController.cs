using AırportMvcUI.ApiServices;
using AırportMvcUI.ApiServices.NewFolder;
using AırportMvcUI.Areas.AdminPanel.Filters;
using AırportMvcUI.Areas.AdminPanel.Models.ApiTypes;
using AırportMvcUI.Areas.AdminPanel.Models.Dtos.Brand;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AırportMvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class BrandController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;
        public BrandController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {
            var response =
        await _apiService.GetData<ResponseBody<List<BrandItem>>>("/Brands");

            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewBrandDto dto, IFormFile brandImage)
        {
			if (brandImage == null)
				return Json(new { IsSuccess = false, Message = "Marka resmi seçilmelidir" });

			if (!brandImage.ContentType.StartsWith("image/"))
				return Json(new { IsSuccess = false, Message = "Sadece resim dosyası seçilmelidir" });

			if (brandImage.Length > 1024 * 1000)
				return Json(new { IsSuccess = false, Message = "Dosya büyüklüğü en fazla 1000 KB olaiblir" });


			var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(brandImage.FileName)}";
			var uploadPath = $@"{_webHost.WebRootPath}/adminPanel/brandImages/{randomFileName}";

			using (var fs = new FileStream(uploadPath, FileMode.Create))
			{
				await brandImage.CopyToAsync(fs);
			}


			// servisle haberleşip kategori bilgisini kaydedilmesini sağlayacağız

			var postData = new 
            {
                
                BrandName = dto.BrandName,
				PicturePath = $@"/adminPanel/brandImages/{randomFileName}",
			};

            var response =
              await _apiService.PostData<ResponseBody<BrandItem>>("/Brands", JsonSerializer.Serialize(postData));

            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Marka Bilgileri Başarıyla Kaydedildi" });

            if (response.ErrorMessages == null)
                return Json(new { IsSuccess = true, Message = "Marka Bilgileri Başarıyla Kaydedildi" });

            var errorMessages = string.Empty;
            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Marka Bilgileri Kaydedilemedi <br /> {errorMessages}"
            });


        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response =
              await _apiService.DeleteData($"/Brands/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Marka Bilgisi Silindi" });

            return Json(new { IsSuccess = false, Message = "Marka Bilgisi  Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetBrand(int id)
        {
            var response =
              await _apiService.GetData<ResponseBody<BrandItem>>($"/Brands/{id}");

            return Json(new
            {
                BrandName = response.Data.BrandName,
                BrandID = response.Data.BrandID
            });

        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateBrandDto dto, IFormFile brandImage)
        {
            if (brandImage == null)
                return Json(new { IsSuccess = false, Message = "Marka resmi seçilmelidir" });

            if (!brandImage.ContentType.StartsWith("image/"))
                return Json(new { IsSuccess = false, Message = "Sadece resim dosyası seçilmelidir" });

            if (brandImage.Length > 1024 * 1000)
                return Json(new { IsSuccess = false, Message = "Dosya büyüklüğü en fazla 1000 KB olaiblir" });


            var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(brandImage.FileName)}";
            var uploadPath = $@"{_webHost.WebRootPath}/adminPanel/brandImages/{randomFileName}";

            using (var fs = new FileStream(uploadPath, FileMode.Create))
            {
                await brandImage.CopyToAsync(fs);
            }


            // servisle haberleşip kategori bilgisini kaydedilmesini sağlayacağız

            var postData = new
            {
                BrandID = dto.BrandID,
                BrandName = dto.BrandName,
                PicturePath = $@"/adminPanel/brandImages/{randomFileName}",
            };

            var response =
              await _apiService.PutData<ResponseBody<BrandItem>>("/Brands", JsonSerializer.Serialize(postData));

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Marka Bilgileri Başarıyla Kaydedildi" });

            if (response.ErrorMessages == null)
                return Json(new { IsSuccess = true, Message = "Marka Bilgileri Başarıyla Kaydedildi" });

            var errorMessages = string.Empty;
            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Marka Bilgileri Kaydedilemedi <br /> {errorMessages}"
            });


        }

    }
}

