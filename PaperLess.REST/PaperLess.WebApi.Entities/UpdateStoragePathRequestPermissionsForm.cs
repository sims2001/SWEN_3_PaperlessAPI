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
    public partial class UpdateStoragePathRequestPermissionsForm 
    {
        /// <summary>
        /// Gets or Sets Owner
        /// </summary>
        [Required]
        [DataMember(Name="owner", EmitDefaultValue=true)]
        public int Owner { get; set; }

        /// <summary>
        /// Gets or Sets SetPermissions
        /// </summary>
        [Required]
        [DataMember(Name="set_permissions", EmitDefaultValue=false)]
        public GetStoragePaths200ResponseResultsInnerPermissions SetPermissions { get; set; }

    }
}
