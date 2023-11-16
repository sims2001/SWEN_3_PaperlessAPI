using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using PaperLess.BusinessLogic.Entities;
using PaperLess.BusinessLogic.Interfaces;
using PaperLess.WebApi.Attributes;
using PaperLess.WebApi.Models;
using Microsoft.Extensions.Logging;

namespace PaperLess.WebApi.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DocumentTypesApiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDocumentTypeLogic _logic;
        private readonly ILogger<DocumentTypesApiController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logic"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DocumentTypesApiController(IDocumentTypeLogic logic, IMapper mapper, ILogger<DocumentTypesApiController> logger)
        {
            _logic = logic ?? throw new ArgumentNullException(nameof(_logic));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createCorrespondentRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/document_types/")]
        [Consumes("application/json")]
        [SwaggerOperation("CreateDocumentType")]
        [SwaggerResponse(statusCode: 200, type: typeof(CreateDocumentType200Response), description: "Success")]
        public virtual IActionResult CreateDocumentType([FromBody]CreateCorrespondentRequest createCorrespondentRequest)
        {
            var newDocType = _mapper.Map<DocumentType>(createCorrespondentRequest);

            var result = _logic.CreateDocumentType(newDocType);

            if (!result.IsSuccess)
                return BadRequest(new { errors = result.Errors });

            var response = _mapper.Map<CreateTag200Response>(result.Result);
            return new ObjectResult(response) {  StatusCode = 200};
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success</response>
        [HttpDelete]
        [Route("/api/document_types/{id}/")]
        [SwaggerOperation("DeleteDocumentType")]
        [SwaggerResponse(statusCode: 204, description: "Success")]
        public virtual IActionResult DeleteDocumentType([FromRoute (Name = "id")][Required]int id)
        {
            var result = _logic.DeleteDocumentType(id);

            if (!result.IsSuccess)
                return BadRequest(new { errors = result.Errors });

            return StatusCode(204);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="fullPerms"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/document_types/")]
        [SwaggerOperation("GetDocumentTypes")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetDocumentTypes200Response), description: "Success")]
        public virtual IActionResult GetDocumentTypes([FromQuery (Name = "page")]int? page, [FromQuery (Name = "full_perms")]bool? fullPerms)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GetDocumentTypes200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"next\" : 6,\n  \"all\" : [ 5, 5 ],\n  \"previous\" : 1,\n  \"count\" : 0,\n  \"results\" : [ {\n    \"owner\" : 9,\n    \"matching_algorithm\" : 2,\n    \"document_count\" : 7,\n    \"is_insensitive\" : true,\n    \"permissions\" : {\n      \"view\" : {\n        \"groups\" : [ \"\", \"\" ],\n        \"users\" : [ \"\", \"\" ]\n      },\n      \"change\" : {\n        \"groups\" : [ \"\", \"\" ],\n        \"users\" : [ \"\", \"\" ]\n      }\n    },\n    \"name\" : \"name\",\n    \"match\" : \"match\",\n    \"id\" : 5,\n    \"slug\" : \"slug\"\n  }, {\n    \"owner\" : 9,\n    \"matching_algorithm\" : 2,\n    \"document_count\" : 7,\n    \"is_insensitive\" : true,\n    \"permissions\" : {\n      \"view\" : {\n        \"groups\" : [ \"\", \"\" ],\n        \"users\" : [ \"\", \"\" ]\n      },\n      \"change\" : {\n        \"groups\" : [ \"\", \"\" ],\n        \"users\" : [ \"\", \"\" ]\n      }\n    },\n    \"name\" : \"name\",\n    \"match\" : \"match\",\n    \"id\" : 5,\n    \"slug\" : \"slug\"\n  } ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetDocumentTypes200Response>(exampleJson)
            : default(GetDocumentTypes200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDocumentTypeRequest"></param>
        /// <response code="200">Success</response>
        [HttpPut]
        [Route("/api/document_types/{id}/")]
        [Consumes("application/json")]
        [SwaggerOperation("UpdateDocumentType")]
        [SwaggerResponse(statusCode: 200, type: typeof(UpdateDocumentType200Response), description: "Success")]
        public virtual IActionResult UpdateDocumentType([FromRoute (Name = "id")][Required]int id, [FromBody]UpdateDocumentTypeRequest updateDocumentTypeRequest)
        {
            var updateDocType = _mapper.Map<DocumentType>(updateDocumentTypeRequest);

            var result = _logic.UpdateDocumentType(id, updateDocType);

            if (!result.IsSuccess)
                return BadRequest(new { errors = result.Errors });

            var response = _mapper.Map<CreateTag200Response>(result.Result);
            return new ObjectResult(response) { StatusCode = 200 };
        }
    }
}
