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
    public partial class AckTasks200Response 
    {
        /// <summary>
        /// Gets or Sets Result
        /// </summary>
        [Required]
        [DataMember(Name="result", EmitDefaultValue=true)]
        public int Result { get; set; }

    }
}
