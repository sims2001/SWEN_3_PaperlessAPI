using System.Runtime.Serialization;

namespace PaperLessApi.Entities
{
    public class Tag
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
        /// Gets or Sets Color
        /// </summary>
        public string Color { get; set; }

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
        /// Gets or Sets IsInboxTag
        /// </summary>
        public bool IsInboxTag { get; set; }

        /// <summary>
        /// Gets or Sets DocumentCount
        /// </summary>
        public long DocumentCount { get; set; }
    }
}
