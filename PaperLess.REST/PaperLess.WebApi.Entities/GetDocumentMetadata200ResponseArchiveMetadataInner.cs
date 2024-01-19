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
    public partial class GetDocumentMetadata200ResponseArchiveMetadataInner 
    {
        /// <summary>
        /// Gets or Sets VarNamespace
        /// </summary>
        [Required]
        [DataMember(Name="namespace", EmitDefaultValue=false)]
        public string VarNamespace { get; set; }

        /// <summary>
        /// Gets or Sets Prefix
        /// </summary>
        [Required]
        [DataMember(Name="prefix", EmitDefaultValue=false)]
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or Sets Key
        /// </summary>
        [Required]
        [DataMember(Name="key", EmitDefaultValue=false)]
        public string Key { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [Required]
        [DataMember(Name="value", EmitDefaultValue=false)]
        public string Value { get; set; }

    }
}
