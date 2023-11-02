
namespace PaperLessApi.Mappers
{
    using AutoMapper;
    using PaperLessApi.DTOs;
    using PaperLessApi.Entities;

    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring 
                cfg.CreateMap<Correspondent, CorrespondentDTO>();
                cfg.CreateMap<CorrespondentDTO, Correspondent>();
                cfg.CreateMap<Correspondent, NewCorrespondentDTO>();
                cfg.CreateMap<NewCorrespondentDTO, Correspondent>();

                cfg.CreateMap<Document, DocumentDTO>();
                cfg.CreateMap<DocumentDTO, Document>();

                cfg.CreateMap<DocumentType, DocumentTypeDTO>();
                cfg.CreateMap<DocumentTypeDTO, DocumentType>();
                cfg.CreateMap<DocumentType, NewDocumentTypeDTO>();
                cfg.CreateMap<NewDocumentTypeDTO, DocumentType>();

                cfg.CreateMap<Tag, TagDTO>();
                cfg.CreateMap<TagDTO, Tag>();
                cfg.CreateMap<Tag, NewTagDTO>();
                cfg.CreateMap<NewTagDTO, Tag>();

                cfg.CreateMap<UserInfo, UserInfoDTO>();
                cfg.CreateMap<UserInfoDTO, UserInfo>();

                //Any Other Mapping Configuration ....
            });

            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
