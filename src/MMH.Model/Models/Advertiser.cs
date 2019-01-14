using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMH.Model.Models
{
    public class Advertiser : IdentityUser
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public int DocumentId { get; set; }
        public Document Document { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("Id")]
        public List<Phone> Phones { get; set; }

        [ForeignKey("Id")]
        public List<DonnationAd> DonnationAd { get; set; }
    }
}
