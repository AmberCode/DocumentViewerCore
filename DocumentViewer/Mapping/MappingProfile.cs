using AutoMapper;
using DocumentViewer.Models;
using DocumentViewer.Services.Model;

namespace DocumentViewer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DocumentListViewModel, Documents>();
        }
    }
}
