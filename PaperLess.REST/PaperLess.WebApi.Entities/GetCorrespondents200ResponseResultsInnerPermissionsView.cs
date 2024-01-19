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
    public partial class GetCorrespondents200ResponseResultsInnerPermissionsView 
    {
        /// <summary>
        /// Gets or Sets Users
        /// </summary>
        [Required]
        [DataMember(Name="users", EmitDefaultValue=false)]
        public List<Object> Users { get; set; }

        /// <summary>
        /// Gets or Sets Groups
        /// </summary>
        [Required]
        [DataMember(Name="groups", EmitDefaultValue=false)]
        public List<Object> Groups { get; set; }

    }
}
