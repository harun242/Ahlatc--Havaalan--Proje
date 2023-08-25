using Infrastructure.Model;
using System.ComponentModel.DataAnnotations;

namespace WS.Model.Entities
{
    public class Brand : IEntity
    {
        [Key]
        public int BrandID { get; set; }
        public string BrandName { get; set; }

		public string? PicturePath { get; set; }

		public bool? IsActive { get; set; } = true;
    }
}
