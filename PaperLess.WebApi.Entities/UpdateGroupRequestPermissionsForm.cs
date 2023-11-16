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
    public partial class UpdateGroupRequestPermissionsForm 
    {
        /// <summary>
        /// Gets or Sets SetPermissions
        /// </summary>
        [Required]
        [DataMember(Name="set_permissions", EmitDefaultValue=false)]
        public List<string> SetPermissions { get; set; }

    }
}
