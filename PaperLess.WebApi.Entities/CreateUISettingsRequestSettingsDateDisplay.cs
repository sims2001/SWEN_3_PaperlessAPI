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
    public partial class CreateUISettingsRequestSettingsDateDisplay 
    {
        /// <summary>
        /// Gets or Sets DateLocale
        /// </summary>
        [Required]
        [DataMember(Name="date_locale", EmitDefaultValue=false)]
        public string DateLocale { get; set; }

        /// <summary>
        /// Gets or Sets DateFormat
        /// </summary>
        [Required]
        [DataMember(Name="date_format", EmitDefaultValue=false)]
        public string DateFormat { get; set; }

    }
}
