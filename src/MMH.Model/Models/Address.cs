using System.ComponentModel.DataAnnotations;

namespace MMH.Model.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        public string Street { get; set; }

        public string Neighborhood { get; set; }

        public string PostalCode { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int StateId { get; set; }
        public State State { get; set; }
    }
}