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
    public partial class GetDocument200ResponsePermissions 
    {
        /// <summary>
        /// Gets or Sets View
        /// </summary>
        [Required]
        [DataMember(Name="view", EmitDefaultValue=false)]
        public GetDocument200ResponsePermissionsView View { get; set; }

        /// <summary>
        /// Gets or Sets Change
        /// </summary>
        [Required]
        [DataMember(Name="change", EmitDefaultValue=false)]
        public GetDocument200ResponsePermissionsView Change { get; set; }

    }
}
