using Infrastructure.Model;
using System.ComponentModel.DataAnnotations;

namespace WS.Model.Dtos.Brand
{
    public class BrandPutDto : IDto
    {
        [Key]
        public int BrandID { get; set; }
        public string? BrandName { get; set; }
        public string? PicturePath { get; set; }

    }
}
