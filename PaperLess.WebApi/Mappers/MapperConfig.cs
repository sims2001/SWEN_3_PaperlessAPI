using PaperLess.BusinessLogic.Entities;
using PaperLess.WebApi.Models;

namespace PaperLess.WebApi.Mappers
{
    using AutoMapper;
    using WebApi.Models;
    using BusinessLogic.Entities;

    /// <summary>
    /// MapperConfig Class for Handling AutoMapping
    /// </summary>
    public class MapperConfig
    {
        /// <summary>
        /// Static Function for an Initial AutoMapper
        /// </summary>
        public static Mapper InitializeRestModelMapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring 
                cfg.CreateMap<Correspondent, CorrespondentDTO>().ReverseMap();
                cfg.CreateMap<Correspondent, NewCorrespondentDTO>().ReverseMap();
                cfg.CreateMap<Correspondent, CreateCorrespondentRequest>().ReverseMap();
                cfg.CreateMap<Correspondent, UpdateCorrespondentRequest>().ReverseMap();
                cfg.CreateMap<Correspondent, GetCorrespondents200Response>().ReverseMap();
                cfg.CreateMap<Correspondent, GetCorrespondents200ResponseResultsInner>().ReverseMap();
                cfg.CreateMap<Correspondent, GetCorrespondents200ResponseResultsInnerPermissions>().ReverseMap();
                cfg.CreateMap<Correspondent, GetCorrespondents200ResponseResultsInnerPermissionsView>().ReverseMap();
                cfg.CreateMap<Correspondent, UpdateCorrespondent200Response>().ReverseMap();
                cfg.CreateMap<Correspondent, UpdateCorrespondentRequest>().ReverseMap();
                cfg.CreateMap<Correspondent, UpdateCorrespondentRequestPermissionsForm>().ReverseMap();

                cfg.CreateMap<Document, DocumentDTO>().ReverseMap();
                cfg.CreateMap<Document, GetDocument200Response>().ReverseMap();
                cfg.CreateMap<Document, GetDocument200ResponsePermissions>().ReverseMap();
                cfg.CreateMap<Document, GetDocument200ResponsePermissionsView>().ReverseMap();
                cfg.CreateMap<Document, GetDocumentMetadata200Response>().ReverseMap();
                cfg.CreateMap<Document, GetDocumentMetadata200ResponseArchiveMetadataInner>().ReverseMap();
                cfg.CreateMap<Document, GetDocuments200Response>().ReverseMap();
                cfg.CreateMap<Document, GetDocuments200ResponseResultsInner>().ReverseMap();
                cfg.CreateMap<Document, GetDocuments200ResponseResultsInnerNotesInner>().ReverseMap();
                cfg.CreateMap<Document, GetDocumentSuggestions200Response>().ReverseMap();
                cfg.CreateMap<Document, UpdateDocument200Response>().ReverseMap();
                cfg.CreateMap<Document, UpdateDocumentRequest>().ReverseMap();

                cfg.CreateMap<DocumentType, DocumentTypeDTO>().ReverseMap();
                cfg.CreateMap<DocumentType, CreateDocumentType200Response>().ReverseMap();
                cfg.CreateMap<DocumentType, GetDocumentTypes200Response>().ReverseMap();
                cfg.CreateMap<DocumentType, GetDocumentTypes200ResponseResultsInner>().ReverseMap();
                cfg.CreateMap<DocumentType, NewDocumentTypeDTO>().ReverseMap();
                cfg.CreateMap<Document, UpdateDocumentType200Response>().ReverseMap();
                cfg.CreateMap<Document, UpdateDocumentTypeRequest>().ReverseMap();

                cfg.CreateMap<Tag, DocTagDTO>().ReverseMap();
                cfg.CreateMap<Tag, CreateTag200Response>().ReverseMap();
                cfg.CreateMap<Tag, CreateTagRequest>().ReverseMap();
                cfg.CreateMap<Tag, GetTags200Response>().ReverseMap();
                cfg.CreateMap<Tag, GetTags200ResponseResultsInner>().ReverseMap();
                cfg.CreateMap<Tag, NewTagDTO>().ReverseMap();
                cfg.CreateMap<Tag, UpdateTag200Response>().ReverseMap();
                cfg.CreateMap<Tag, UpdateTagRequest>().ReverseMap();

                cfg.CreateMap<UserInfo, UserInfoDTO>().ReverseMap();
            });

            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
