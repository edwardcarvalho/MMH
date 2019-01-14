using System.ComponentModel.DataAnnotations;

namespace MMH.Model.Models
{
    public class Phone
    {
        [Key]
        public int PhoneId { get; set; }

        public int DDD { get; set; }

        public int Number { get; set; }

        public string Id { get; set; }
        public virtual Advertiser Advertiser { get; set; }

    }
}