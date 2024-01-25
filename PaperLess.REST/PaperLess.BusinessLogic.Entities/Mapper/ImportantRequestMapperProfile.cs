using AutoMapper;
using PaperLess.WebApi.Entities;

namespace PaperLess.BusinessLogic.Entities.Mapper {

    public class ImportantRequestMapperProfile : Profile {
        public ImportantRequestMapperProfile() {
            CreateMap<CreateDocumentRequest, Document>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore mapping Id from CreateDocumentRequest
            .ForMember(dest => dest.Content, opt => opt.Ignore())
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created ?? DateTime.UtcNow))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.Created ?? DateTime.UtcNow))
            .ForMember(dest => dest.Modified, opt => opt.MapFrom(src => src.Created ?? DateTime.UtcNow)) // Ignore mapping Modified from CreateDocumentRequest
            .ForMember(dest => dest.Added, opt => opt.MapFrom(src => src.Created ?? DateTime.UtcNow)) // Ignore mapping Added from CreateDocumentRequest
            .ForMember(dest => dest.ArchiveSerialNumber, opt => opt.Ignore()) // Ignore mapping ArchiveSerialNumber from CreateDocumentRequest
            .ForMember(dest => dest.OriginalFileName, opt => opt.Ignore()) // Ignore mapping OriginalFileName from CreateDocumentRequest
            .ForMember(dest => dest.ArchivedFileName, opt => opt.Ignore()) // Ignore mapping ArchivedFileName from CreateDocumentRequest
            .ForMember(dest => dest.UploadDocument, opt => opt.MapFrom(src => src.Document));
        }
    }

}