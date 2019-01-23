using System;

namespace DocumentViewer.Models
{
    public class DocumentListViewModel
    {
        public long Id { get; set; }
        public long DocumentNumber { get; set; }
        public string DocumentName { get; set; }
        public DateTime Datetime { get; set; }
    }
}
