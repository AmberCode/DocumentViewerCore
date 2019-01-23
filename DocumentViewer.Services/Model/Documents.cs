using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentViewer.Services.Model
{
    public partial class Documents
    {
        [Column("ID")]
        public long Id { get; set; }
        public long DocumentNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string DocumentName { get; set; }
        [Required]
        public byte[] Document { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
    }
}
