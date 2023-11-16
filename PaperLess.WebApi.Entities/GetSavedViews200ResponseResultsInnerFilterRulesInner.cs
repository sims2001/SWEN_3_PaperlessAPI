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
    public partial class GetSavedViews200ResponseResultsInnerFilterRulesInner 
    {
        /// <summary>
        /// Gets or Sets RuleType
        /// </summary>
        [Required]
        [DataMember(Name="rule_type", EmitDefaultValue=true)]
        public int RuleType { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [Required]
        [DataMember(Name="value", EmitDefaultValue=false)]
        public string Value { get; set; }

    }
}
