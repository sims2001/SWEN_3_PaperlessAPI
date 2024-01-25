using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using PaperLess.BusinessLogic.Interfaces;
using PaperLess.BusinessLogic.Interfaces.BlExceptions;
using PaperLess.WebApi.Attributes;
using PaperLess.WebApi.Entities;
using PaperLess.Elastic.Interfaces;

namespace PaperLess.WebApi.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class SearchApiController : ControllerBase
    { 
        private readonly ISearchLogic _searchLogic;
        private readonly ILogger<SearchApiController> _logger;
        public SearchApiController(ISearchLogic searchLogic, ILogger<SearchApiController> logger)
        {
            _searchLogic = searchLogic;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/search/")]
        [ValidateModelState]
        [SwaggerOperation("SearchDocuments")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ElasticDoc>), description: "Success")]
        public virtual IActionResult SearchDocuments([FromQuery (Name = "searchTerm")]string searchTerm)
        {
            try {
                _logger.LogInformation($"Search Request for: {searchTerm}");
                var foundDocs = _searchLogic.SearchDocument(searchTerm);

                return new ObjectResult(foundDocs);
            } catch (BlExceptionBase e) {
                _logger.LogError($"An Exception occurred in the Business Layer: {e.Message}");
                return StatusCode(500);
            } catch (Exception e) {
                _logger.LogError($"An unknown Exception occurred: {e.Message}");
                return StatusCode(500);
            }
        }
    }
}
