using System.ComponentModel.DataAnnotations;

namespace MMH.Model.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }
    }
}