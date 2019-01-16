using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Advertiser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
