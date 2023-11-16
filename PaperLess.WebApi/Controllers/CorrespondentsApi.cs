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
    public class CorrespondentsApiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICorrespondentLogic _logic;
        private readonly ILogger<CorrespondentsApiController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logic"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public CorrespondentsApiController(ICorrespondentLogic logic, IMapper mapper, ILogger<CorrespondentsApiController> logger)
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
        [Route("/api/correspondents/")]
        [Consumes("application/json")]
        [SwaggerOperation("CreateCorrespondent")]
        [SwaggerResponse(statusCode: 200, type: typeof(CreateCorrespondentRequest), description: "Success")]
        public virtual IActionResult CreateCorrespondent([FromBody]CreateCorrespondentRequest createCorrespondentRequest)
        {
            var newCorrespondent = _mapper.Map<Correspondent>(createCorrespondentRequest);

            var result = _logic.CreateCorrespondent(newCorrespondent);

            if (!result.IsSuccess)
                return BadRequest(new { errors = result.Errors });

            var response = _mapper.Map<CreateCorrespondentRequest>(result.Result);
            return new ObjectResult(response) { StatusCode = 200 };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success</response>
        [HttpDelete]
        [Route("/api/correspondents/{id}/")]
        [SwaggerResponse(statusCode: 204, description: "Success")]
        public virtual IActionResult DeleteCorrespondent([FromRoute (Name = "id")][Required]int id)
        {
            var result = _logic.DeleteCorrespondent(id);

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
        [Route("/api/correspondents/")]
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
        [SwaggerOperation("UpdateCorrespondent")]
        [SwaggerResponse(statusCode: 200, type: typeof(UpdateCorrespondent200Response), description: "Success")]
        public virtual IActionResult UpdateCorrespondent([FromRoute (Name = "id")][Required]int id, [FromBody]UpdateCorrespondentRequest updateCorrespondentRequest)
        {
            var updateCorrespondent = _mapper.Map<Correspondent>(updateCorrespondentRequest);

            var result = _logic.UpdateCorrespondent(id, updateCorrespondent);

            if (!result.IsSuccess)
                return BadRequest(new { errors = result.Errors });

            var response = _mapper.Map<UpdateCorrespondent200Response>(result.Result);
            return new ObjectResult(response) { StatusCode = 200 };
        }
    }
}
