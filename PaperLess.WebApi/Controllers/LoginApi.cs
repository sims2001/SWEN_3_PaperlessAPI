using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using PaperLess.WebApi.Mappers;
using PaperLess.WebApi.Attributes;
using PaperLess.WebApi.Entities;

namespace PaperLess.WebApi.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class LoginApiController : ControllerBase
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/")]
        [ValidateModelState]
        [SwaggerOperation("ApiGet")]
        public virtual IActionResult ApiGet()
        {
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createGroupRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/groups/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("CreateGroup")]
        [SwaggerResponse(statusCode: 200, type: typeof(Object), description: "Success")]
        public virtual IActionResult CreateGroup([FromBody]CreateGroupRequest createGroupRequest)
        {

            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Object>(exampleJson)
            : default(Object);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createUserRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/users/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("CreateUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetUsers200ResponseResultsInner), description: "Success")]
        public virtual IActionResult CreateUser([FromBody]CreateUserRequest createUserRequest)
        {

            string exampleJson = null;
            exampleJson = "{\n  \"is_active\" : true,\n  \"is_superuser\" : true,\n  \"user_permissions\" : [ \"\", \"\" ],\n  \"is_staff\" : true,\n  \"last_name\" : \"last_name\",\n  \"groups\" : [ \"\", \"\" ],\n  \"password\" : \"password\",\n  \"id\" : 5,\n  \"date_joined\" : \"date_joined\",\n  \"first_name\" : \"first_name\",\n  \"email\" : \"email\",\n  \"username\" : \"username\",\n  \"inherited_permissions\" : [ \"inherited_permissions\", \"inherited_permissions\" ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetUsers200ResponseResultsInner>(exampleJson)
            : default(GetUsers200ResponseResultsInner);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success</response>
        [HttpDelete]
        [Route("/api/groups/{id}/")]
        [ValidateModelState]
        [SwaggerOperation("DeleteGroup")]
        public virtual IActionResult DeleteGroup([FromRoute (Name = "id")][Required]int id)
        {

            //TODO: RETURN GROUPS

            return StatusCode(204);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success</response>
        [HttpDelete]
        [Route("/api/users/{id}/")]
        [ValidateModelState]
        [SwaggerOperation("DeleteUser")]
        public virtual IActionResult DeleteUser([FromRoute (Name = "id")][Required]int id)
        {

            //TODO: DELETE USER?
            return StatusCode(204);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/groups/")]
        [ValidateModelState]
        [SwaggerOperation("GetGroups")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetGroups200Response), description: "Success")]
        public virtual IActionResult GetGroups([FromQuery (Name = "page")]int? page, [FromQuery (Name = "page_size")]int? pageSize)
        {

            string exampleJson = null;
            exampleJson = "{\n  \"next\" : 6,\n  \"all\" : [ \"\", \"\" ],\n  \"previous\" : 1,\n  \"count\" : 0,\n  \"results\" : [ \"\", \"\" ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetGroups200Response>(exampleJson)
            : default(GetGroups200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInfo"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/token/")]
        [Consumes("application/json", "text/json", "application/*+json")]
        [ValidateModelState]
        [SwaggerOperation("GetToken")]
        public virtual IActionResult GetToken([FromBody]UserInfoDTO userInfo)
        {

            if (userInfo.Username == "user" && userInfo.Password == "password")
                return Ok(new { Token = "asdasd" });
            else if (userInfo.Username == "admin" && userInfo.Password == "admin")
                return Ok(new { Token = "aaddmmiinn" });
            else
                return Unauthorized();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/users/")]
        [ValidateModelState]
        [SwaggerOperation("GetUsers")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetUsers200Response), description: "Success")]
        public virtual IActionResult GetUsers([FromQuery (Name = "page")]int? page, [FromQuery (Name = "page_size")]int? pageSize)
        {

            string exampleJson = null;
            exampleJson = "{\n  \"next\" : 6,\n  \"all\" : [ 5, 5 ],\n  \"previous\" : 1,\n  \"count\" : 0,\n  \"results\" : [ {\n    \"is_active\" : true,\n    \"is_superuser\" : true,\n    \"user_permissions\" : [ \"\", \"\" ],\n    \"is_staff\" : true,\n    \"last_name\" : \"last_name\",\n    \"groups\" : [ \"\", \"\" ],\n    \"password\" : \"password\",\n    \"id\" : 5,\n    \"date_joined\" : \"date_joined\",\n    \"first_name\" : \"first_name\",\n    \"email\" : \"email\",\n    \"username\" : \"username\",\n    \"inherited_permissions\" : [ \"inherited_permissions\", \"inherited_permissions\" ]\n  }, {\n    \"is_active\" : true,\n    \"is_superuser\" : true,\n    \"user_permissions\" : [ \"\", \"\" ],\n    \"is_staff\" : true,\n    \"last_name\" : \"last_name\",\n    \"groups\" : [ \"\", \"\" ],\n    \"password\" : \"password\",\n    \"id\" : 5,\n    \"date_joined\" : \"date_joined\",\n    \"first_name\" : \"first_name\",\n    \"email\" : \"email\",\n    \"username\" : \"username\",\n    \"inherited_permissions\" : [ \"inherited_permissions\", \"inherited_permissions\" ]\n  } ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetUsers200Response>(exampleJson)
            : default(GetUsers200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/")]
        [ValidateModelState]
        [SwaggerOperation("Root")]
        public virtual IActionResult Root()
        {

            return Ok();

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/statistics/")]
        [ValidateModelState]
        [SwaggerOperation("Statistics")]
        [SwaggerResponse(statusCode: 200, type: typeof(Statistics200Response), description: "Success")]
        public virtual IActionResult Statistics()
        {

            string exampleJson = null;
            exampleJson = "{\n  \"document_file_type_counts\" : [ {\n    \"mime_type\" : \"mime_type\",\n    \"mime_type_count\" : 5\n  }, {\n    \"mime_type\" : \"mime_type\",\n    \"mime_type_count\" : 5\n  } ],\n  \"documents_inbox\" : 6,\n  \"inbox_tag\" : 1,\n  \"documents_total\" : 0,\n  \"character_count\" : 5\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Statistics200Response>(exampleJson)
            : default(Statistics200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateGroupRequest"></param>
        /// <response code="200">Success</response>
        [HttpPut]
        [Route("/api/groups/{id}/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("UpdateGroup")]
        [SwaggerResponse(statusCode: 200, type: typeof(UpdateGroup200Response), description: "Success")]
        public virtual IActionResult UpdateGroup([FromRoute (Name = "id")][Required]int id, [FromBody]UpdateGroupRequest updateGroupRequest)
        {

            string exampleJson = null;
            exampleJson = "{\n  \"permissions\" : [ \"permissions\", \"permissions\" ],\n  \"name\" : \"name\",\n  \"id\" : 0\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<UpdateGroup200Response>(exampleJson)
            : default(UpdateGroup200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateUserRequest"></param>
        /// <response code="200">Success</response>
        [HttpPut]
        [Route("/api/users/{id}/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("UpdateUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetUsers200ResponseResultsInner), description: "Success")]
        public virtual IActionResult UpdateUser([FromRoute (Name = "id")][Required]int id, [FromBody]UpdateUserRequest updateUserRequest)
        {

            string exampleJson = null;
            exampleJson = "{\n  \"is_active\" : true,\n  \"is_superuser\" : true,\n  \"user_permissions\" : [ \"\", \"\" ],\n  \"is_staff\" : true,\n  \"last_name\" : \"last_name\",\n  \"groups\" : [ \"\", \"\" ],\n  \"password\" : \"password\",\n  \"id\" : 5,\n  \"date_joined\" : \"date_joined\",\n  \"first_name\" : \"first_name\",\n  \"email\" : \"email\",\n  \"username\" : \"username\",\n  \"inherited_permissions\" : [ \"inherited_permissions\", \"inherited_permissions\" ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetUsers200ResponseResultsInner>(exampleJson)
            : default(GetUsers200ResponseResultsInner);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
