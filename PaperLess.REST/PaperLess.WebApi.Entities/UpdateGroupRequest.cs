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
    public partial class UpdateGroupRequest 
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        [DataMember(Name="id", EmitDefaultValue=true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Permissions
        /// </summary>
        [Required]
        [DataMember(Name="permissions", EmitDefaultValue=false)]
        public List<string> Permissions { get; set; }

        /// <summary>
        /// Gets or Sets SetPermissions
        /// </summary>
        [Required]
        [DataMember(Name="set_permissions", EmitDefaultValue=false)]
        public List<string> SetPermissions { get; set; }

        /// <summary>
        /// Gets or Sets PermissionsForm
        /// </summary>
        [Required]
        [DataMember(Name="permissions_form", EmitDefaultValue=false)]
        public UpdateGroupRequestPermissionsForm PermissionsForm { get; set; }

    }
}
