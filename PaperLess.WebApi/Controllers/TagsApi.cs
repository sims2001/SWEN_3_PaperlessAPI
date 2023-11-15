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
using PaperLess.BusinessLogic.Validation;
using PaperLess.WebApi.Attributes;
using PaperLess.WebApi.Models;

namespace PaperLess.WebApi.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class TagsApiController : ControllerBase {
        private readonly IMapper _mapper;
        private readonly ITagLogic _logic;

        public TagsApiController(ITagLogic logic, IMapper mapper) {
            _logic = logic;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createTagRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/tags/")]
        [Consumes("application/json")]
        [SwaggerOperation("CreateTag")]
        [SwaggerResponse(statusCode: 200, type: typeof(CreateTag200Response), description: "Success")]
        public virtual IActionResult CreateTag([FromBody]CreateTagRequest createTagRequest) {
            var newTag = _mapper.Map<Tag>(createTagRequest);

            var result = _logic.NewTag(newTag);

            if (!result.IsSuccess)
                return BadRequest(new { errors = result.Errors } ); 

            var response = _mapper.Map<CreateTag200Response>(result.Result);
            return new ObjectResult(response) { StatusCode = 200 };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success</response>
        [HttpDelete]
        [Route("/api/tags/{id}/")]
        [SwaggerOperation("DeleteTag")]
        [SwaggerResponse(statusCode: 204, description: "Success")]
        public virtual IActionResult DeleteTag([FromRoute (Name = "id")][Required]int id)
        {
            var result = _logic.DeleteTag(id);

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
        [Route("/api/tags/")]
        [SwaggerOperation("GetTags")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetTags200Response), description: "Success")]
        public virtual IActionResult GetTags([FromQuery (Name = "page")]int? page, [FromQuery (Name = "full_perms")]bool? fullPerms)
        {

            

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GetTags200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"next\" : 6,\n  \"all\" : [ 5, 5 ],\n  \"previous\" : 1,\n  \"count\" : 0,\n  \"results\" : [ {\n    \"owner\" : 9,\n    \"matching_algorithm\" : 2,\n    \"document_count\" : 7,\n    \"color\" : \"color\",\n    \"is_insensitive\" : true,\n    \"permissions\" : {\n      \"view\" : {\n        \"groups\" : [ \"\", \"\" ],\n        \"users\" : [ \"\", \"\" ]\n      },\n      \"change\" : {\n        \"groups\" : [ \"\", \"\" ],\n        \"users\" : [ \"\", \"\" ]\n      }\n    },\n    \"name\" : \"name\",\n    \"match\" : \"match\",\n    \"id\" : 5,\n    \"text_color\" : \"text_color\",\n    \"is_inbox_tag\" : true,\n    \"slug\" : \"slug\"\n  }, {\n    \"owner\" : 9,\n    \"matching_algorithm\" : 2,\n    \"document_count\" : 7,\n    \"color\" : \"color\",\n    \"is_insensitive\" : true,\n    \"permissions\" : {\n      \"view\" : {\n        \"groups\" : [ \"\", \"\" ],\n        \"users\" : [ \"\", \"\" ]\n      },\n      \"change\" : {\n        \"groups\" : [ \"\", \"\" ],\n        \"users\" : [ \"\", \"\" ]\n      }\n    },\n    \"name\" : \"name\",\n    \"match\" : \"match\",\n    \"id\" : 5,\n    \"text_color\" : \"text_color\",\n    \"is_inbox_tag\" : true,\n    \"slug\" : \"slug\"\n  } ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetTags200Response>(exampleJson)
            : default(GetTags200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateTagRequest"></param>
        /// <response code="200">Success</response>
        [HttpPut]
        [Route("/api/tags/{id}/")]
        [Consumes("application/json")]
        [SwaggerOperation("UpdateTag")]
        [SwaggerResponse(statusCode: 200, type: typeof(UpdateTag200Response), description: "Success")]
        public virtual IActionResult UpdateTag([FromRoute (Name = "id")][Required]int id, [FromBody]UpdateTagRequest updateTagRequest)
        {

            Tag updateTag = _mapper.Map<Tag>(updateTagRequest);
            BusinessLogicResult<Tag> result = _logic.UpdateTag(id, updateTag);

            if (!result.IsSuccess)
                return BadRequest(new { errors = result.Errors });

            UpdateTag200Response response = _mapper.Map<UpdateTag200Response>(result.Result);
            return new ObjectResult(response) { StatusCode = 200 };
        }
    }
}
