using System.ComponentModel.DataAnnotations;

namespace MMH.Model.Models
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }

        public int DocumentTypeId { get; set; }
        public DocumentType Type { get; set; }

        public string Number { get; set; }
    }
}