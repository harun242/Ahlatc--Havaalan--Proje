using Infrastructure.Model;

namespace WS.Model.Dtos.Brand
{
    public class BrandGetDto :IDto
    {
        public int BrandID { get; set; }
        public string? BrandName { get; set; }

		public string? PicturePath { get; set; }
	}
}
