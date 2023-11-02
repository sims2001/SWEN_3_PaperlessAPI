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
    public class ConfigApiController : ControllerBase
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createSavedViewsRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/saved_views/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("CreateSavedViews")]
        public virtual IActionResult CreateSavedViews([FromBody]CreateSavedViewsRequest createSavedViewsRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            return StatusCode(200);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createStoragePathRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/storage_paths/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("CreateStoragePath")]
        [SwaggerResponse(statusCode: 200, type: typeof(CreateStoragePath200Response), description: "Success")]
        public virtual IActionResult CreateStoragePath([FromBody]CreateStoragePathRequest createStoragePathRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(CreateStoragePath200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"owner\" : 1,\n  \"path\" : \"path\",\n  \"matching_algorithm\" : 6,\n  \"user_can_change\" : true,\n  \"is_insensitive\" : true,\n  \"name\" : \"name\",\n  \"match\" : \"match\",\n  \"id\" : 0,\n  \"slug\" : \"slug\"\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<CreateStoragePath200Response>(exampleJson)
            : default(CreateStoragePath200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createUISettingsRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/ui_settings/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("CreateUISettings")]
        [SwaggerResponse(statusCode: 200, type: typeof(CreateUISettings200Response), description: "Success")]
        public virtual IActionResult CreateUISettings([FromBody]CreateUISettingsRequest createUISettingsRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(CreateUISettings200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"success\" : true\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<CreateUISettings200Response>(exampleJson)
            : default(CreateUISettings200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success</response>
        [HttpDelete]
        [Route("/api/storage_paths/{id}/")]
        [ValidateModelState]
        [SwaggerOperation("DeleteStoragePath")]
        public virtual IActionResult DeleteStoragePath([FromRoute (Name = "id")][Required]int id)
        {

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/ws/status/")]
        [ValidateModelState]
        [SwaggerOperation("Get")]
        public virtual IActionResult Get()
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            return StatusCode(200);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/logs/{id}/")]
        [ValidateModelState]
        [SwaggerOperation("GetLog")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<string>), description: "Success")]
        public virtual IActionResult GetLog([FromRoute (Name = "id")][Required]string id)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<string>));
            string exampleJson = null;
            exampleJson = "[ \"\", \"\" ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<string>>(exampleJson)
            : default(List<string>);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/logs/")]
        [ValidateModelState]
        [SwaggerOperation("GetLogs")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<string>), description: "Success")]
        public virtual IActionResult GetLogs()
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<string>));
            string exampleJson = null;
            exampleJson = "[ \"\", \"\" ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<string>>(exampleJson)
            : default(List<string>);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/saved_views/")]
        [ValidateModelState]
        [SwaggerOperation("GetSavedViews")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetSavedViews200Response), description: "Success")]
        public virtual IActionResult GetSavedViews([FromQuery (Name = "page")]int? page, [FromQuery (Name = "page_size")]int? pageSize)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GetSavedViews200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"next\" : 6,\n  \"all\" : [ 5, 5 ],\n  \"previous\" : 1,\n  \"count\" : 0,\n  \"results\" : [ {\n    \"owner\" : {\n      \"is_superuser\" : true,\n      \"is_active\" : true,\n      \"user_permissions\" : [ 9, 9 ],\n      \"is_staff\" : true,\n      \"last_login\" : \"last_login\",\n      \"last_name\" : \"last_name\",\n      \"groups\" : [ \"\", \"\" ],\n      \"password\" : \"password\",\n      \"id\" : 7,\n      \"date_joined\" : \"date_joined\",\n      \"first_name\" : \"first_name\",\n      \"email\" : \"email\",\n      \"username\" : \"username\"\n    },\n    \"user_can_change\" : true,\n    \"sort_field\" : \"sort_field\",\n    \"show_on_dashboard\" : true,\n    \"name\" : \"name\",\n    \"show_in_sidebar\" : true,\n    \"filter_rules\" : [ {\n      \"rule_type\" : 2,\n      \"value\" : \"value\"\n    }, {\n      \"rule_type\" : 2,\n      \"value\" : \"value\"\n    } ],\n    \"sort_reverse\" : true,\n    \"id\" : 5\n  }, {\n    \"owner\" : {\n      \"is_superuser\" : true,\n      \"is_active\" : true,\n      \"user_permissions\" : [ 9, 9 ],\n      \"is_staff\" : true,\n      \"last_login\" : \"last_login\",\n      \"last_name\" : \"last_name\",\n      \"groups\" : [ \"\", \"\" ],\n      \"password\" : \"password\",\n      \"id\" : 7,\n      \"date_joined\" : \"date_joined\",\n      \"first_name\" : \"first_name\",\n      \"email\" : \"email\",\n      \"username\" : \"username\"\n    },\n    \"user_can_change\" : true,\n    \"sort_field\" : \"sort_field\",\n    \"show_on_dashboard\" : true,\n    \"name\" : \"name\",\n    \"show_in_sidebar\" : true,\n    \"filter_rules\" : [ {\n      \"rule_type\" : 2,\n      \"value\" : \"value\"\n    }, {\n      \"rule_type\" : 2,\n      \"value\" : \"value\"\n    } ],\n    \"sort_reverse\" : true,\n    \"id\" : 5\n  } ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetSavedViews200Response>(exampleJson)
            : default(GetSavedViews200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="fullPerms"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/storage_paths/")]
        [ValidateModelState]
        [SwaggerOperation("GetStoragePaths")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetStoragePaths200Response), description: "Success")]
        public virtual IActionResult GetStoragePaths([FromQuery (Name = "page")]int? page, [FromQuery (Name = "full_perms")]bool? fullPerms)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GetStoragePaths200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"next\" : true,\n  \"all\" : [ 6, 6 ],\n  \"previous\" : true,\n  \"count\" : 0,\n  \"results\" : [ {\n    \"owner\" : 2,\n    \"path\" : \"path\",\n    \"matching_algorithm\" : 5,\n    \"document_count\" : 5,\n    \"is_insensitive\" : true,\n    \"permissions\" : {\n      \"view\" : {\n        \"groups\" : [ \"\", \"\" ],\n        \"users\" : [ 7, 7 ]\n      },\n      \"change\" : {\n        \"groups\" : [ \"\", \"\" ],\n        \"users\" : [ 7, 7 ]\n      }\n    },\n    \"name\" : \"name\",\n    \"match\" : \"match\",\n    \"id\" : 1,\n    \"slug\" : \"slug\"\n  }, {\n    \"owner\" : 2,\n    \"path\" : \"path\",\n    \"matching_algorithm\" : 5,\n    \"document_count\" : 5,\n    \"is_insensitive\" : true,\n    \"permissions\" : {\n      \"view\" : {\n        \"groups\" : [ \"\", \"\" ],\n        \"users\" : [ 7, 7 ]\n      },\n      \"change\" : {\n        \"groups\" : [ \"\", \"\" ],\n        \"users\" : [ 7, 7 ]\n      }\n    },\n    \"name\" : \"name\",\n    \"match\" : \"match\",\n    \"id\" : 1,\n    \"slug\" : \"slug\"\n  } ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetStoragePaths200Response>(exampleJson)
            : default(GetStoragePaths200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/ui_settings/")]
        [ValidateModelState]
        [SwaggerOperation("GetUISettings")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetUISettings200Response), description: "Success")]
        public virtual IActionResult GetUISettings()
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GetUISettings200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"settings\" : {\n    \"update_checking\" : {\n      \"backend_setting\" : \"backend_setting\"\n    }\n  },\n  \"permissions\" : [ \"permissions\", \"permissions\" ],\n  \"display_name\" : \"display_name\",\n  \"user\" : {\n    \"is_superuser\" : true,\n    \"groups\" : [ \"\", \"\" ],\n    \"id\" : 0,\n    \"username\" : \"username\"\n  }\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetUISettings200Response>(exampleJson)
            : default(GetUISettings200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateStoragePathRequest"></param>
        /// <response code="200">Success</response>
        [HttpPut]
        [Route("/api/storage_paths/{id}/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("UpdateStoragePath")]
        [SwaggerResponse(statusCode: 200, type: typeof(UpdateStoragePath200Response), description: "Success")]
        public virtual IActionResult UpdateStoragePath([FromRoute (Name = "id")][Required]int id, [FromBody]UpdateStoragePathRequest updateStoragePathRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(UpdateStoragePath200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"owner\" : 5,\n  \"path\" : \"path\",\n  \"matching_algorithm\" : 6,\n  \"user_can_change\" : true,\n  \"document_count\" : 1,\n  \"is_insensitive\" : true,\n  \"name\" : \"name\",\n  \"match\" : \"match\",\n  \"id\" : 0,\n  \"slug\" : \"slug\"\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<UpdateStoragePath200Response>(exampleJson)
            : default(UpdateStoragePath200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
