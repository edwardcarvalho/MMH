using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMH.Model.Models
{
    public class Picture
    {
        [Key]
        public long PictureId { get; set; }

        public string Name { get; set; }

        public byte[] ImageData { get; set; }

        public long DonnationAdId { get; set; }
        public DonnationAd Donnation { get; set; }
    }
}