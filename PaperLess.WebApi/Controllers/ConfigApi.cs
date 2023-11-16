using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using PaperLess.WebApi.Attributes;
using PaperLess.WebApi.Entities;

namespace PaperLess.WebApi.Controllers
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
            // return StatusCode(204);

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
            // return StatusCode(200);

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

            Console.WriteLine("WTF IS HAPPENING???");

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            //return StatusCode(200, default(GetSavedViews200Response));
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

            Console.WriteLine("WTF IS HAPPENING???");
            string result = @"{
                ""display_name"": ""max"",
                ""user"": {
                    ""id"": 3,
                    ""username"": ""max"",
                    ""is_superuser"": true,
                    ""groups"": []
                },
                ""settings"": {
                    ""update_checking"": {
                        ""enabled"": false,
                        ""backend_setting"": ""default""
                    },
                    ""bulk_edit"": {
                        ""apply_on_close"": false,
                        ""confirmation_dialogs"": true
                    },
                    ""documentListSize"": 50,
                    ""slim_sidebar"": false,
                    ""dark_mode"": {
                        ""use_system"": true,
                        ""enabled"": ""false"",
                        ""thumb_inverted"": ""false""
                    },
                    ""theme"": {
                        ""color"": """"
                    },
                    ""document_details"": {
                        ""native_pdf_viewer"": true
                    },
                    ""date_display"": {
                        ""date_locale"": """",
                        ""date_format"": ""mediumDate""
                    },
                    ""notifications"": {
                        ""consumer_new_documents"": true,
                        ""consumer_success"": true,
                        ""consumer_failed"": true,
                        ""consumer_suppress_on_dashboard"": true
                    },
                    ""comments_enabled"": true,
                    ""language"": """"
                },
                ""permissions"": [
                    ""view_userobjectpermission"",
                    ""delete_failure"",
                    ""view_uisettings"",
                    ""change_user"",
                    ""delete_task"",
                    ""change_group"",
                    ""change_savedviewfilterrule"",
                    ""add_ormq"",
                    ""view_contenttype"",
                    ""add_mailaccount"",
                    ""add_storagepath"",
                    ""add_document"",
                    ""change_uisettings"",
                    ""view_paperlesstask"",
                    ""change_log"",
                    ""add_comment"",
                    ""add_log"",
                    ""view_user"",
                    ""change_groupobjectpermission"",
                    ""delete_mailrule"",
                    ""view_taskresult"",
                    ""add_correspondent"",
                    ""view_savedview"",
                    ""change_correspondent"",
                    ""change_groupresult"",
                    ""delete_group"",
                    ""add_savedview"",
                    ""delete_note"",
                    ""view_permission"",
                    ""add_savedviewfilterrule"",
                    ""change_comment"",
                    ""add_session"",
                    ""change_processedmail"",
                    ""add_taskresult"",
                    ""change_document"",
                    ""add_group"",
                    ""view_log"",
                    ""change_note"",
                    ""add_success"",
                    ""change_contenttype"",
                    ""add_permission"",
                    ""change_mailrule"",
                    ""delete_schedule"",
                    ""view_savedviewfilterrule"",
                    ""view_task"",
                    ""add_token"",
                    ""delete_user"",
                    ""delete_contenttype"",
                    ""add_user"",
                    ""add_chordcounter"",
                    ""add_note"",
                    ""add_failure"",
                    ""view_session"",
                    ""add_documenttype"",
                    ""view_correspondent"",
                    ""add_paperlesstask"",
                    ""change_taskresult"",
                    ""delete_chordcounter"",
                    ""view_token"",
                    ""delete_savedview"",
                    ""delete_groupobjectpermission"",
                    ""view_schedule"",
                    ""add_processedmail"",
                    ""change_tag"",
                    ""change_userobjectpermission"",
                    ""delete_documenttype"",
                    ""delete_processedmail"",
                    ""view_mailaccount"",
                    ""delete_token"",
                    ""delete_savedviewfilterrule"",
                    ""add_tokenproxy"",
                    ""add_mailrule"",
                    ""view_documenttype"",
                    ""delete_tag"",
                    ""add_contenttype"",
                    ""add_task"",
                    ""add_schedule"",
                    ""change_token"",
                    ""change_ormq"",
                    ""delete_permission"",
                    ""delete_storagepath"",
                    ""view_tokenproxy"",
                    ""delete_logentry"",
                    ""delete_correspondent"",
                    ""delete_tokenproxy"",
                    ""change_success"",
                    ""delete_document"",
                    ""change_logentry"",
                    ""view_failure"",
                    ""add_uisettings"",
                    ""change_permission"",
                    ""change_savedview"",
                    ""delete_groupresult"",
                    ""add_groupresult"",
                    ""view_logentry"",
                    ""delete_paperlesstask"",
                    ""change_task"",
                    ""view_storagepath"",
                    ""view_groupobjectpermission"",
                    ""delete_success"",
                    ""view_groupresult"",
                    ""add_groupobjectpermission"",
                    ""delete_log"",
                    ""view_ormq"",
                    ""add_logentry"",
                    ""view_success"",
                    ""delete_ormq"",
                    ""change_paperlesstask"",
                    ""delete_uisettings"",
                    ""change_failure"",
                    ""change_session"",
                    ""view_mailrule"",
                    ""add_userobjectpermission"",
                    ""view_tag"",
                    ""delete_mailaccount"",
                    ""delete_taskresult"",
                    ""delete_session"",
                    ""change_mailaccount"",
                    ""view_comment"",
                    ""view_note"",
                    ""change_tokenproxy"",
                    ""change_storagepath"",
                    ""view_chordcounter"",
                    ""change_schedule"",
                    ""change_chordcounter"",
                    ""view_processedmail"",
                    ""add_tag"",
                    ""view_group"",
                    ""view_document"",
                    ""delete_comment"",
                    ""delete_userobjectpermission"",
                    ""change_documenttype""
                ]
            }";

            return new ObjectResult(result);



            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            //return StatusCode(200, default(GetUISettings200Response));
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
