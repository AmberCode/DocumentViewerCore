using AutoMapper;
using DocumentViewer.Controllers;
using DocumentViewer.Mapping;
using DocumentViewer.Services.Services;
using Xunit;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;
using DocumentViewer.Services.Model;
using System;
using System.Linq;
using DocumentViewer.Models;

namespace DocumentViewer.Services.Tests
{
    public class DocumentControllerTests
    {
        static DocumentControllerTests()
        {
            Mapper.Initialize(x => x.AddProfile<MappingProfile>());
        }

        [Fact]
        public async Task GetAll_Ok()
        {
            var mockDocumentService = new Mock<IDocumentSevice>();
            mockDocumentService.Setup(x => x.SearchDocuments(null, null, null)).ReturnsAsync(new List<Documents>{
                new Documents
                {
                    Id = 1,
                    DocumentNumber = 1,
                    DocumentName = "Test",
                    Document = new byte[0],
                    DateTime = DateTime.Now
                }
            });

            var searchRequest = new SearchRequestModel
            {
                DocDate = null,
                DocName = null,
                DocNumber = null
            };

            var controller = new DocumentController(Mapper.Instance, mockDocumentService.Object);
            var result = await controller.SearchDocuments(searchRequest);

            Assert.Single(result);
        }

        [Fact]
        public async Task Document_Ok()
        {
            var mockDocumentService = new Mock<IDocumentSevice>();
            mockDocumentService.Setup(x => x.GetDocument(1)).ReturnsAsync(new Documents
            {
                Id = 1,
                DocumentNumber = 1,
                DocumentName = "Test",
                Document = new byte[0],
                DateTime = DateTime.Now
            });

            var controller = new DocumentController(Mapper.Instance, mockDocumentService.Object);
            var result = await controller.Document(1);

            Assert.IsType<DocumentDisplayViewModel>(result);
            Assert.True(result.Id == 1);
        }

        [Fact]
        public async Task SearchDocuments_Ok()
        {
            var mockDocumentService = new Mock<IDocumentSevice>();
            mockDocumentService.Setup(x => x.SearchDocuments(null, null, 9)).ReturnsAsync(new List<Documents>{
                new Documents
                {
                    Id = 9,
                    DocumentNumber = 9999,
                    DocumentName = "Test",
                    Document = new byte[0],
                    DateTime = DateTime.Now
                }
            });

            var controller = new DocumentController(Mapper.Instance, mockDocumentService.Object);
            var result = await controller.SearchDocuments(new SearchRequestModel
            {
                DocDate = null,
                DocName = null,
                DocNumber = 9
            });

            Assert.True(result.Count() == 1);
            Assert.True(result.First().Id == 9);
        }
    }
}
