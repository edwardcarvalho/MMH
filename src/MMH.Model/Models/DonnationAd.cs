using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMH.Model.Models
{
    public class DonnationAd
    {
        [Key]
        public long DonnationAdId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [ForeignKey("PictureId")]
        public virtual List<Picture> Pictures { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public int SubGroupId { get; set; }
        public virtual SubGroup SubGroup { get; set; }

        public string Id { get; set; }
        public virtual Advertiser Advertiser { get; set; }
    }
}