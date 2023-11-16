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
    public partial class AckTasksRequest 
    {
        /// <summary>
        /// Gets or Sets Tasks
        /// </summary>
        [Required]
        [DataMember(Name="tasks", EmitDefaultValue=false)]
        public List<int> Tasks { get; set; }

    }
}
