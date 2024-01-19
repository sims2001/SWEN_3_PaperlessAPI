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
    public partial class GetUISettings200Response 
    {
        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>
        [Required]
        [DataMember(Name="display_name", EmitDefaultValue=false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or Sets User
        /// </summary>
        [Required]
        [DataMember(Name="user", EmitDefaultValue=false)]
        public GetUISettings200ResponseUser User { get; set; }

        /// <summary>
        /// Gets or Sets Settings
        /// </summary>
        [Required]
        [DataMember(Name="settings", EmitDefaultValue=false)]
        public GetUISettings200ResponseSettings Settings { get; set; }

        /// <summary>
        /// Gets or Sets Permissions
        /// </summary>
        [Required]
        [DataMember(Name="permissions", EmitDefaultValue=false)]
        public List<string> Permissions { get; set; }

    }
}
