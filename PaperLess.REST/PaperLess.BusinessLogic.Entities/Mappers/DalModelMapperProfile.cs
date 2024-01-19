using AutoMapper;
using PaperLess.DataAccess.Entities;

namespace PaperLess.BusinessLogic.Entities.Mappers;

public class DalModelMapperProfile : Profile
{
    public DalModelMapperProfile() {
        CreateMap<Document, DocumentDAL>().ReverseMap();

        CreateMap<Correspondent, CorrespondentDAL>().ReverseMap();

        CreateMap<Tag, TagDAL>().ReverseMap();

        CreateMap<DocumentType, DocumentTypeDAL>().ReverseMap();
    }
}
