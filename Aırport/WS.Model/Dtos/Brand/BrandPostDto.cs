using Infrastructure.Model;

namespace WS.Model.Dtos.Brand
{
    public class BrandPostDto: IDto
    {      
        public string? BrandName { get; set; }

		public string? PicturePath { get; set; }
	}
}
