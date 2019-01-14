using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMH.Model.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }

        public string Name { get; set; }

        public List<City> Cidades { get; set; }
    }
}