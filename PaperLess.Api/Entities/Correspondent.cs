using System.Runtime.Serialization;
using System;

namespace PaperLess.Api.Entities
{
    /// <summary>
    /// Correspondant Entity for working in the Controllers
    /// </summary>
    public class Correspondent
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or Sets Slug
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Match
        /// </summary>
        public string Match { get; set; }

        /// <summary>
        /// Gets or Sets MatchingAlgorithm
        /// </summary>
        public long MatchingAlgorithm { get; set; }

        /// <summary>
        /// Gets or Sets IsInsensitive
        /// </summary>
        public bool IsInsensitive { get; set; }

        /// <summary>
        /// Gets or Sets DocumentCount
        /// </summary>
        public long DocumentCount { get; set; }

        /// <summary>
        /// Gets or Sets LastCorrespondence
        /// </summary>
        public DateTime LastCorrespondence { get; set; }

    }
}