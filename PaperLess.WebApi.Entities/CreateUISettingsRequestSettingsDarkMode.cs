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
    public partial class CreateUISettingsRequestSettingsDarkMode 
    {
        /// <summary>
        /// Gets or Sets UseSystem
        /// </summary>
        [Required]
        [DataMember(Name="use_system", EmitDefaultValue=true)]
        public bool UseSystem { get; set; }

        /// <summary>
        /// Gets or Sets Enabled
        /// </summary>
        [Required]
        [DataMember(Name="enabled", EmitDefaultValue=false)]
        public string Enabled { get; set; }

        /// <summary>
        /// Gets or Sets ThumbInverted
        /// </summary>
        [Required]
        [DataMember(Name="thumb_inverted", EmitDefaultValue=false)]
        public string ThumbInverted { get; set; }

    }
}
