using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaperLess.WebApi.Entities {
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class CreateDocumentRequest {
        [Required]
        [DataMember(Name = "title", EmitDefaultValue = false)]
        [FromForm(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "created", EmitDefaultValue = true)]
        [FromForm(Name = "created")]
        public DateTime? Created { get; set; }

        [DataMember(Name= "document_type", EmitDefaultValue = true)]
        [FromForm(Name = "document_type")]
        public int? DocumentType { get; set; }

        [DataMember(Name = "tags", EmitDefaultValue = true)]
        [FromForm(Name = "tags")]
        public List<int>? Tags { get; set; } 

        [DataMember(Name= "correspondent", EmitDefaultValue = true)]
        [FromForm(Name = "correspondent")]
        public int? Correspondent { get; set; }
        
        [Required]
        [DataMember(Name="document", EmitDefaultValue = false)]
        [FromForm(Name = "document")]
        public IFormFile Document { get; set; }

    }
}
