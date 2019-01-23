using DocumentViewer.Services.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace DocumentViewer.Services.Services
{
    public interface IDocumentSevice
    {
        Task<IEnumerable<Documents>> SearchDocuments(DateTime? date, string documentName, long? documentNumber);
        Task<Documents> GetDocument(long id);
    }
}
