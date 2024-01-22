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
        /// <param name="term"></param>
        /// <param name="limit"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/search/")]
        [ValidateModelState]
        [SwaggerOperation("Search")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<string>), description: "Success")]
        public virtual IActionResult AutoComplete([FromQuery (Name = "term")]string term)
        {
            var foundDocs = _elastic.SearchDocument(term);

            return new ObjectResult(foundDocs);
        }
    }
}
