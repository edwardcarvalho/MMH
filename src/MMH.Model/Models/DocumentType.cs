using System.ComponentModel.DataAnnotations;

namespace MMH.Model.Models
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeId { get; set; }

        public string Name { get; set; }
    }
}