using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentViewer.Services.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DocumentViewer.Services.Services
{
    public class DocumentService : IDocumentSevice
    {
        private readonly TestContext _testContext;

        public DocumentService(TestContext testContext)
        {
            _testContext = testContext;
        }

        public async Task<Documents> GetDocument(long id)
        {
            return await _testContext.Documents.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Documents>> SearchDocuments(DateTime? date, string documentName, long? documentNumber)
        {
                return await _testContext.Documents.Where(x => (!date.HasValue || x.DateTime.Date == date.Value.Date) &&
                    (string.IsNullOrEmpty(documentName) || x.DocumentName.Contains(documentName)) &&
                    (!documentNumber.HasValue || x.DocumentNumber == documentNumber)).ToListAsync();
        }
    }
}
