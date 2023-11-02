using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using PaperLessApi.Attributes;
using PaperLessApi.DTOs;
using PaperLessApi.Models;

namespace PaperLessApi.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class CorrespondentsApiController : ControllerBase
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createCorrespondentRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/correspondents/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("CreateCorrespondent")]
        [SwaggerResponse(statusCode: 200, type: typeof(CreateCorrespondentRequest), description: "Success")]
        public virtual IActionResult CreateCorrespondent([FromBody]CreateCorrespondentRequest createCorrespondentRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(CreateCorrespondentRequest));
            string exampleJson = null;
            exampleJson = "{\n  \"owner\" : 6,\n  \"matching_algorithm\" : 0,\n  \"is_insensitive\" : true,\n  \"name\" : \"name\",\n  \"match\" : \"match\"\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<CreateCorrespondentRequest>(exampleJson)
            : default(CreateCorrespondentRequest);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success</response>
        [HttpDelete]
        [Route("/api/correspondents/{id}/")]
        [ValidateModelState]
        [SwaggerOperation("DeleteCorrespondent")]
        public virtual IActionResult DeleteCorrespondent([FromRoute (Name = "id")][Required]int id)
        {

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="fullPerms"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/correspondents/")]
        [ValidateModelState]
        [SwaggerOperation("GetCorrespondents")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetCorrespondents200Response), description: "Success")]
        public virtual IActionResult GetCorrespondents([FromQuery (Name = "page")]int? page, [FromQuery (Name = "full_perms")]bool? fullPerms)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GetCorrespondents200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"next\" : 6,\n  \"all\" : [ 5, 5 ],\n  \"previous\" : 1,\n  \"count\" : 0,\n  \"results\" : [ {\n    \"owner\" : 9,\n    \"matching_algorithm\" : 2,\n    \"document_count\" : 7,\n    \"is_insensitive\" : true,\n    \"permissions\" : {\n      \"view\" : {\n        \"groups\" : [ \"\", \"\" ],\n        \"users\" : [ \"\", \"\" ]\n      },\n      \"change\" : {\n        \"groups\" : [ \"\", \"\" ],\n        \"users\" : [ \"\", \"\" ]\n      }\n    },\n    \"name\" : \"name\",\n    \"match\" : \"match\",\n    \"id\" : 5,\n    \"last_correspondence\" : \"last_correspondence\",\n    \"slug\" : \"slug\"\n  }, {\n    \"owner\" : 9,\n    \"matching_algorithm\" : 2,\n    \"document_count\" : 7,\n    \"is_insensitive\" : true,\n    \"permissions\" : {\n      \"view\" : {\n        \"groups\" : [ \"\", \"\" ],\n        \"users\" : [ \"\", \"\" ]\n      },\n      \"change\" : {\n        \"groups\" : [ \"\", \"\" ],\n        \"users\" : [ \"\", \"\" ]\n      }\n    },\n    \"name\" : \"name\",\n    \"match\" : \"match\",\n    \"id\" : 5,\n    \"last_correspondence\" : \"last_correspondence\",\n    \"slug\" : \"slug\"\n  } ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetCorrespondents200Response>(exampleJson)
            : default(GetCorrespondents200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateCorrespondentRequest"></param>
        /// <response code="200">Success</response>
        [HttpPut]
        [Route("/api/correspondents/{id}/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("UpdateCorrespondent")]
        [SwaggerResponse(statusCode: 200, type: typeof(UpdateCorrespondent200Response), description: "Success")]
        public virtual IActionResult UpdateCorrespondent([FromRoute (Name = "id")][Required]int id, [FromBody]UpdateCorrespondentRequest updateCorrespondentRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(UpdateCorrespondent200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"owner\" : 5,\n  \"matching_algorithm\" : 6,\n  \"user_can_change\" : true,\n  \"document_count\" : 1,\n  \"is_insensitive\" : true,\n  \"name\" : \"name\",\n  \"match\" : \"match\",\n  \"id\" : 0,\n  \"last_correspondence\" : 5,\n  \"slug\" : \"slug\"\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<UpdateCorrespondent200Response>(exampleJson)
            : default(UpdateCorrespondent200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
