using AutoMapper;
using PaperLess.WebApi.Entities;

namespace PaperLess.BusinessLogic.Entities.Mapper;

public class RestModelMapperProfile : Profile
{
    public RestModelMapperProfile() {
        CreateMap<Correspondent, CorrespondentDTO>().ReverseMap();
        CreateMap<Correspondent, NewCorrespondentDTO>().ReverseMap();
        CreateMap<Correspondent, CreateCorrespondentRequest>().ReverseMap();
        CreateMap<Correspondent, UpdateCorrespondentRequest>().ReverseMap();

        //TODO: CHECK THOSE -> Maybe map slug from ID+Name?
        CreateMap<Correspondent, GetCorrespondents200Response>().ReverseMap();
        CreateMap<Correspondent, GetCorrespondents200ResponseResultsInner>().ReverseMap();
        CreateMap<Correspondent, GetCorrespondents200ResponseResultsInnerPermissions>().ReverseMap();
        CreateMap<Correspondent, GetCorrespondents200ResponseResultsInnerPermissionsView>().ReverseMap();
        CreateMap<Correspondent, UpdateCorrespondent200Response>().ReverseMap();
        CreateMap<Correspondent, UpdateCorrespondentRequestPermissionsForm>().ReverseMap();

        CreateMap<Document, DocumentDTO>().ReverseMap();
        CreateMap<Document, GetDocument200Response>().ReverseMap();
        CreateMap<Document, GetDocument200ResponsePermissions>().ReverseMap();
        CreateMap<Document, GetDocument200ResponsePermissionsView>().ReverseMap();
        CreateMap<Document, GetDocumentMetadata200Response>().ReverseMap();
        CreateMap<Document, GetDocumentMetadata200ResponseArchiveMetadataInner>().ReverseMap();
        CreateMap<Document, GetDocuments200Response>().ReverseMap();
        CreateMap<Document, GetDocuments200ResponseResultsInner>().ReverseMap();
        CreateMap<Document, GetDocuments200ResponseResultsInnerNotesInner>().ReverseMap();
        CreateMap<Document, GetDocumentSuggestions200Response>().ReverseMap();
        CreateMap<Document, UpdateDocument200Response>().ReverseMap();
        CreateMap<Document, UpdateDocumentRequest>().ReverseMap();

        CreateMap<DocumentType, DocumentTypeDTO>().ReverseMap();
        CreateMap<DocumentType, CreateDocumentType200Response>().ReverseMap();
        CreateMap<DocumentType, GetDocumentTypes200Response>().ReverseMap();
        CreateMap<DocumentType, GetDocumentTypes200ResponseResultsInner>().ReverseMap();
        CreateMap<DocumentType, NewDocumentTypeDTO>().ReverseMap();
        CreateMap<Document, UpdateDocumentType200Response>().ReverseMap();
        CreateMap<Document, UpdateDocumentTypeRequest>().ReverseMap();

        CreateMap<Tag, DocTagDTO>().ReverseMap();
        CreateMap<Tag, CreateTag200Response>().ReverseMap();
        CreateMap<Tag, CreateTagRequest>().ReverseMap();
        CreateMap<Tag, GetTags200Response>().ReverseMap();
        CreateMap<Tag, GetTags200ResponseResultsInner>().ReverseMap();
        CreateMap<Tag, NewTagDTO>().ReverseMap();
        CreateMap<Tag, UpdateTag200Response>().ReverseMap();
        CreateMap<Tag, UpdateTagRequest>().ReverseMap();

        CreateMap<UserInfo, UserInfoDTO>().ReverseMap();
    }
}
