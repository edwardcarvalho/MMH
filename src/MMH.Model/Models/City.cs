using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMH.Model.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        public string Name { get; set; }
        
        public int StateId { get; set; }
        public State State { get; set; }
    }
}