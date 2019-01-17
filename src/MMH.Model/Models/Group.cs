using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMH.Model.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        public string Name { get; set; }

        [ForeignKey("SubGroupId")]
        public virtual List<SubGroup> SubGroups { get; set; }

    }
}