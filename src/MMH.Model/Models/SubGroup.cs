using System.ComponentModel.DataAnnotations;

namespace MMH.Model.Models
{
    public class SubGroup
    {
        [Key]
        public int SubGroupId { get; set; }

        public string Name { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}