using Microsoft.AspNetCore.Http;

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using PaperLess.WebApi.Entities.Converters;

namespace PaperLess.WebApi.Entities
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Statistics200ResponseDocumentFileTypeCountsInner 
    {
        /// <summary>
        /// Gets or Sets MimeType
        /// </summary>
        [Required]
        [DataMember(Name="mime_type", EmitDefaultValue=false)]
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or Sets MimeTypeCount
        /// </summary>
        [Required]
        [DataMember(Name="mime_type_count", EmitDefaultValue=true)]
        public int MimeTypeCount { get; set; }

    }
}
