using System.ComponentModel.DataAnnotations;

namespace MMH.Model.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        public string Name { get; set; }
    }
}