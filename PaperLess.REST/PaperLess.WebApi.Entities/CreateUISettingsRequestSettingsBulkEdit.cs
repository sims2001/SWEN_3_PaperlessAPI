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
    public partial class CreateUISettingsRequestSettingsBulkEdit 
    {
        /// <summary>
        /// Gets or Sets ApplyOnClose
        /// </summary>
        [Required]
        [DataMember(Name="apply_on_close", EmitDefaultValue=true)]
        public bool ApplyOnClose { get; set; }

        /// <summary>
        /// Gets or Sets ConfirmationDialogs
        /// </summary>
        [Required]
        [DataMember(Name="confirmation_dialogs", EmitDefaultValue=true)]
        public bool ConfirmationDialogs { get; set; }

    }
}
