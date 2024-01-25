using AutoMapper;
using PaperLess.BusinessLogic.Entities;

namespace PaperLess.DataAccess.Entities.Mapper;

public class DalModelMapperProfile : Profile
{
    public DalModelMapperProfile() {
        CreateMap<Document, DocumentDAL>().ReverseMap();

        CreateMap<Correspondent, CorrespondentDAL>().ReverseMap();

        CreateMap<Tag, TagDAL>().ReverseMap();

        CreateMap<DocumentType, DocumentTypeDAL>().ReverseMap();
    }
}
