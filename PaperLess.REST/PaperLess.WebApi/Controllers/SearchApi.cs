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
using PaperLess.Elastic.Interfaces;

namespace PaperLess.WebApi.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class SearchApiController : ControllerBase
    { 
        private readonly IElasticSearcher _elastic;
        public SearchApiController(IElasticSearcher elastic) {
            _elastic = elastic;
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
            var foundDocs = _elastic.SearchDocument(searchTerm);

            return new ObjectResult(foundDocs);
        }
    }
}
