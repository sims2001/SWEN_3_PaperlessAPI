using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace PaperLessApi.Entities
{
    /// <summary>
    /// Document Entity for working in the Controllers
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Correspondent
        /// </summary>
        public int? Correspondent { get; set; }

        /// <summary>
        /// Gets or Sets DocumentType
        /// </summary>
        public int? DocumentType { get; set; }

        /// <summary>
        /// Gets or Sets StoragePath
        /// </summary>
        public int? StoragePath { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        public List<int> Tags { get; set; }

        /// <summary>
        /// Gets or Sets Created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or Sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets Modified
        /// </summary>
        public DateTime Modified { get; set; }

        /// <summary>
        /// Gets or Sets Added
        /// </summary>
        public DateTime Added { get; set; }

        /// <summary>
        /// Gets or Sets ArchiveSerialNumber
        /// </summary>
        public string ArchiveSerialNumber { get; set; }

        /// <summary>
        /// Gets or Sets OriginalFileName
        /// </summary>
        public string OriginalFileName { get; set; }

        /// <summary>
        /// Gets or Sets ArchivedFileName
        /// </summary>
        public string ArchivedFileName { get; set; }
    }
}
