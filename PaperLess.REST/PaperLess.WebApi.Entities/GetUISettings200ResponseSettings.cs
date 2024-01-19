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
    public partial class GetUISettings200ResponseSettings 
    {
        /// <summary>
        /// Gets or Sets UpdateChecking
        /// </summary>
        [Required]
        [DataMember(Name="update_checking", EmitDefaultValue=false)]
        public GetUISettings200ResponseSettingsUpdateChecking UpdateChecking { get; set; }

    }
}
