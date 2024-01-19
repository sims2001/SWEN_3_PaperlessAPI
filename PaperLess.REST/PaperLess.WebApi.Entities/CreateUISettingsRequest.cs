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
    public partial class CreateUISettingsRequest 
    {
        /// <summary>
        /// Gets or Sets Settings
        /// </summary>
        [Required]
        [DataMember(Name="settings", EmitDefaultValue=false)]
        public CreateUISettingsRequestSettings Settings { get; set; }

    }
}
