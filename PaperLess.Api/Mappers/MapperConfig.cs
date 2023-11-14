
using PaperLess.Api.DTOs;
using PaperLess.Api.Entities;

namespace PaperLess.Api.Mappers
{
    using AutoMapper;
    using Api.DTOs;
    using Api.Entities;

    /// <summary>
    /// MapperConfig Class for Handling AutoMapping
    /// </summary>
    public class MapperConfig
    {
        /// <summary>
        /// Static Function for an Initial AutoMapper
        /// </summary>
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
