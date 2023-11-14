using System.Runtime.Serialization;

namespace PaperLess.Api.Entities
{
    /// <summary>
    /// UserInfo Entity for working in the Controllers
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// Gets or Sets Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        public string Password { get; set; }
    }
}
