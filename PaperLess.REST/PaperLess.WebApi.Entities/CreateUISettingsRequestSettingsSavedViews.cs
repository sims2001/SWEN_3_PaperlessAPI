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
    public partial class CreateUISettingsRequestSettingsSavedViews 
    {
        /// <summary>
        /// Gets or Sets WarnOnUnsavedChange
        /// </summary>
        [Required]
        [DataMember(Name="warn_on_unsaved_change", EmitDefaultValue=true)]
        public bool WarnOnUnsavedChange { get; set; }

    }
}
