using System;

namespace DocumentViewer.Models
{
    public class SearchRequestModel
    {
        public DateTime? DocDate { get; set; }
        public string DocName { get; set; }
        public long? DocNumber { get; set; }
    }
}
