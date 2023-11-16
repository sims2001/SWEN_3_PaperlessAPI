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
    public partial class CreateUISettings200Response 
    {
        /// <summary>
        /// Gets or Sets Success
        /// </summary>
        [Required]
        [DataMember(Name="success", EmitDefaultValue=true)]
        public bool Success { get; set; }

    }
}
