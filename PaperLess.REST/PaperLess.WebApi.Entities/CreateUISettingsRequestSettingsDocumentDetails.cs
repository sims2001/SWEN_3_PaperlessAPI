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
    public partial class CreateUISettingsRequestSettingsDocumentDetails 
    {
        /// <summary>
        /// Gets or Sets NativePdfViewer
        /// </summary>
        [Required]
        [DataMember(Name="native_pdf_viewer", EmitDefaultValue=true)]
        public bool NativePdfViewer { get; set; }

    }
}
