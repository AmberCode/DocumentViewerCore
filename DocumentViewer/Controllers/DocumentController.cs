using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentViewer.Models;
using Microsoft.AspNetCore.Mvc;
using DocumentViewer.Services.Services;
using System.Threading.Tasks;
using AutoMapper;

namespace DocumentViewer.Controllers
{
    [Route("api/[controller]")]
    public class DocumentController
    {
        private readonly IMapper _mapper;
        private readonly IDocumentSevice _documentService;

        public DocumentController(IMapper mapper, IDocumentSevice documentService)
        {
            _mapper = mapper;
            _documentService = documentService;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<DocumentListViewModel>> GetAll()
        {
            var documents = await _documentService.SearchDocuments(null, "", null);
            return documents.Select(x => _mapper.Map<DocumentListViewModel>(x));
        }

        [HttpPost("[action]")]
        public async Task<IEnumerable<DocumentListViewModel>> SearchDocuments([FromBody]SearchRequestModel searchRequest)
        {
            var documents = await _documentService.SearchDocuments(
                searchRequest.DocDate,
                searchRequest.DocName,
                searchRequest.DocNumber);

            return documents.Select(x => _mapper.Map<DocumentListViewModel>(x));
        }

        [HttpGet("[action]")]
        public async Task<DocumentDisplayViewModel> Document(int id)
        {
            var document = await _documentService.GetDocument(id);

            return new DocumentDisplayViewModel
            {
                Id = document.Id,
                FileType = Path.GetExtension(document.DocumentName).Replace(".", ""),
                FileName = document.DocumentName,
                File = Convert.ToBase64String(document.Document)
            };
        }
    }
}
