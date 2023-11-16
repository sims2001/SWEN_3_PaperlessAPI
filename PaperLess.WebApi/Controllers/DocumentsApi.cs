using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using PaperLess.BusinessLogic;
using PaperLess.BusinessLogic.Entities;
using PaperLess.BusinessLogic.Interfaces;
using PaperLess.WebApi.Attributes;
using Microsoft.Extensions.Logging;
using PaperLess.WebApi.Entities;

namespace PaperLess.WebApi.Controllers
{
    /// <summary>
    /// </summary>
    [ApiController]
    public class DocumentsApiController : ControllerBase {
        private readonly IMapper _mapper;
        private readonly IDocumentLogic _logic;
        private readonly ILogger<DocumentsApiController> _logger;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logic"></param>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <exception cref="ArgumentNullException"></exception>
        public DocumentsApiController(IDocumentLogic logic, IMapper mapper, ILogger<DocumentsApiController> logger) {
            _logic = logic ?? throw new ArgumentNullException(nameof(_logic));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }


        /// <summary>
        /// </summary>
        /// <param name="bulkEditRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/documents/bulk_edit/")]
        [Consumes("application/json")]
        [SwaggerOperation("BulkEdit")]
        public virtual IActionResult BulkEdit([FromBody]BulkEditRequest bulkEditRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            return StatusCode(200);

            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success</response>
        [HttpDelete]
        [Route("/api/documents/{id}/")]
        [SwaggerOperation("DeleteDocument")]
        [SwaggerResponse(statusCode: 204, description: "Success")]
        public virtual IActionResult DeleteDocument([FromRoute (Name = "id")][Required]int id) {
            var result = _logic.DeleteDocument(id);

            if (!result.IsSuccess)
                return BadRequest(new { errors = result.Errors });

            return StatusCode(204);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="original"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/download/")]
        [SwaggerOperation("DownloadDocument")]
        [SwaggerResponse(statusCode: 200, type: typeof(System.IO.Stream), description: "Success")]
        public virtual IActionResult DownloadDocument([FromRoute (Name = "id")][Required]int id, [FromQuery (Name = "original")]bool? original)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(System.IO.Stream));
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<System.IO.Stream>(exampleJson)
            : default(System.IO.Stream);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="fullPerms"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/")]
        [SwaggerOperation("GetDocument")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetDocument200Response), description: "Success")]
        public virtual IActionResult GetDocument([FromRoute (Name = "id")][Required]int id, [FromQuery (Name = "page")]int? page, [FromQuery (Name = "full_perms")]bool? fullPerms) {
            var getDoc = _logic.GetDocument(id, page, fullPerms);

            if(! getDoc.IsSuccess)
                return BadRequest(new { errors = getDoc.Errors });

            var response = _mapper.Map<GetDocument200Response>(getDoc.Result);
            return new ObjectResult(response) { StatusCode = 200 };
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/metadata/")]
        [SwaggerOperation("GetDocumentMetadata")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetDocumentMetadata200Response), description: "Success")]
        public virtual IActionResult GetDocumentMetadata([FromRoute (Name = "id")][Required]int id)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GetDocumentMetadata200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"archive_size\" : 6,\n  \"archive_metadata\" : [ {\n    \"prefix\" : \"prefix\",\n    \"namespace\" : \"namespace\",\n    \"value\" : \"value\",\n    \"key\" : \"key\"\n  }, {\n    \"prefix\" : \"prefix\",\n    \"namespace\" : \"namespace\",\n    \"value\" : \"value\",\n    \"key\" : \"key\"\n  } ],\n  \"original_metadata\" : [ \"\", \"\" ],\n  \"original_filename\" : \"original_filename\",\n  \"original_mime_type\" : \"original_mime_type\",\n  \"archive_checksum\" : \"archive_checksum\",\n  \"original_checksum\" : \"original_checksum\",\n  \"lang\" : \"lang\",\n  \"media_filename\" : \"media_filename\",\n  \"has_archive_version\" : true,\n  \"archive_media_filename\" : \"archive_media_filename\",\n  \"original_size\" : 0\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetDocumentMetadata200Response>(exampleJson)
            : default(GetDocumentMetadata200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/preview/")]
        [SwaggerOperation("GetDocumentPreview")]
        [SwaggerResponse(statusCode: 200, type: typeof(System.IO.Stream), description: "Success")]
        public virtual IActionResult GetDocumentPreview([FromRoute (Name = "id")][Required]int id)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(System.IO.Stream));
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<System.IO.Stream>(exampleJson)
            : default(System.IO.Stream);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/suggestions/")]
        [SwaggerOperation("GetDocumentSuggestions")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetDocumentSuggestions200Response), description: "Success")]
        public virtual IActionResult GetDocumentSuggestions([FromRoute (Name = "id")][Required]int id)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GetDocumentSuggestions200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"storage_paths\" : [ \"\", \"\" ],\n  \"document_types\" : [ \"\", \"\" ],\n  \"dates\" : [ \"\", \"\" ],\n  \"correspondents\" : [ \"\", \"\" ],\n  \"tags\" : [ \"\", \"\" ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetDocumentSuggestions200Response>(exampleJson)
            : default(GetDocumentSuggestions200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/thumb/")]
        [SwaggerOperation("GetDocumentThumb")]
        [SwaggerResponse(statusCode: 200, type: typeof(System.IO.Stream), description: "Success")]
        public virtual IActionResult GetDocumentThumb([FromRoute (Name = "id")][Required]int id)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(System.IO.Stream));
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<System.IO.Stream>(exampleJson)
            : default(System.IO.Stream);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="query"></param>
        /// <param name="ordering"></param>
        /// <param name="tagsIdAll"></param>
        /// <param name="documentTypeId"></param>
        /// <param name="storagePathIdIn"></param>
        /// <param name="correspondentId"></param>
        /// <param name="truncateContent"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/")]
        [SwaggerOperation("GetDocuments")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetDocuments200Response), description: "Success")]
        public virtual IActionResult GetDocuments([FromQuery (Name = "Page")]int? page, [FromQuery (Name = "page_size")]int? pageSize, [FromQuery (Name = "query")]string query, [FromQuery (Name = "ordering")]string ordering, [FromQuery (Name = "tags__id__all")]List<int> tagsIdAll, [FromQuery (Name = "document_type__id")]int? documentTypeId, [FromQuery (Name = "storage_path__id__in")]int? storagePathIdIn, [FromQuery (Name = "correspondent__id")]int? correspondentId, [FromQuery (Name = "truncate_content")]bool? truncateContent)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GetDocuments200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"next\" : 6,\n  \"all\" : [ 5, 5 ],\n  \"previous\" : 1,\n  \"count\" : 0,\n  \"results\" : [ {\n    \"owner\" : 4,\n    \"user_can_change\" : true,\n    \"archive_serial_number\" : 2,\n    \"notes\" : [ {\n      \"note\" : \"note\",\n      \"created\" : \"created\",\n      \"document\" : 1,\n      \"id\" : 7,\n      \"user\" : 1\n    }, {\n      \"note\" : \"note\",\n      \"created\" : \"created\",\n      \"document\" : 1,\n      \"id\" : 7,\n      \"user\" : 1\n    } ],\n    \"added\" : \"added\",\n    \"created\" : \"created\",\n    \"title\" : \"title\",\n    \"content\" : \"content\",\n    \"tags\" : [ 3, 3 ],\n    \"storage_path\" : 9,\n    \"archived_file_name\" : \"archived_file_name\",\n    \"modified\" : \"modified\",\n    \"correspondent\" : 2,\n    \"original_file_name\" : \"original_file_name\",\n    \"id\" : 5,\n    \"created_date\" : \"created_date\",\n    \"document_type\" : 7\n  }, {\n    \"owner\" : 4,\n    \"user_can_change\" : true,\n    \"archive_serial_number\" : 2,\n    \"notes\" : [ {\n      \"note\" : \"note\",\n      \"created\" : \"created\",\n      \"document\" : 1,\n      \"id\" : 7,\n      \"user\" : 1\n    }, {\n      \"note\" : \"note\",\n      \"created\" : \"created\",\n      \"document\" : 1,\n      \"id\" : 7,\n      \"user\" : 1\n    } ],\n    \"added\" : \"added\",\n    \"created\" : \"created\",\n    \"title\" : \"title\",\n    \"content\" : \"content\",\n    \"tags\" : [ 3, 3 ],\n    \"storage_path\" : 9,\n    \"archived_file_name\" : \"archived_file_name\",\n    \"modified\" : \"modified\",\n    \"correspondent\" : 2,\n    \"original_file_name\" : \"original_file_name\",\n    \"id\" : 5,\n    \"created_date\" : \"created_date\",\n    \"document_type\" : 7\n  } ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetDocuments200Response>(exampleJson)
            : default(GetDocuments200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectionDataRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/documents/selection_data/")]
        [Consumes("application/json")]
        [SwaggerOperation("SelectionData")]
        [SwaggerResponse(statusCode: 200, type: typeof(SelectionData200Response), description: "Success")]
        public virtual IActionResult SelectionData([FromBody]SelectionDataRequest selectionDataRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(SelectionData200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"selected_storage_paths\" : [ {\n    \"document_count\" : 6,\n    \"id\" : 0\n  }, {\n    \"document_count\" : 6,\n    \"id\" : 0\n  } ],\n  \"selected_document_types\" : [ {\n    \"document_count\" : 6,\n    \"id\" : 0\n  }, {\n    \"document_count\" : 6,\n    \"id\" : 0\n  } ],\n  \"selected_correspondents\" : [ {\n    \"document_count\" : 6,\n    \"id\" : 0\n  }, {\n    \"document_count\" : 6,\n    \"id\" : 0\n  } ],\n  \"selected_tags\" : [ {\n    \"document_count\" : 6,\n    \"id\" : 0\n  }, {\n    \"document_count\" : 6,\n    \"id\" : 0\n  } ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<SelectionData200Response>(exampleJson)
            : default(SelectionData200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDocumentRequest"></param>
        /// <response code="200">Success</response>
        [HttpPut]
        [Route("/api/documents/{id}/")]
        [Consumes("application/json")]
        [SwaggerOperation("UpdateDocument")]
        [SwaggerResponse(statusCode: 200, type: typeof(UpdateDocument200Response), description: "Success")]
        public virtual IActionResult UpdateDocument([FromRoute (Name = "id")][Required]int id, [FromBody]UpdateDocumentRequest updateDocumentRequest)
        {
            var updateDoc = _mapper.Map<Document>(updateDocumentRequest);

            var result = _logic.UpdateDocument(id, updateDoc);

            if (!result.IsSuccess)
                return BadRequest(new { errors = result.Errors });

            var response = _mapper.Map<CreateTag200Response>(result.Result);
            return new ObjectResult(response) { StatusCode = 200 };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newDocumentRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/documents/post_document/")]
        [Consumes("multipart/form-data")]
        [SwaggerOperation("UploadDocument")]
        public virtual async Task<IActionResult> UploadDocument([FromForm] CreateDocumentRequest newDocumentRequest) {

            var newDocument = _mapper.Map<Document>(newDocumentRequest);
            
            using (var streamReader = new StreamReader(newDocumentRequest.Document.OpenReadStream())) {
                newDocument.Content = await streamReader.ReadToEndAsync();
            }
            
            var result = _logic.CreateDocument(newDocument);

            if (!result.IsSuccess)
                return BadRequest(new { errors = result.Errors });

            return Ok();
        }
    }
}
