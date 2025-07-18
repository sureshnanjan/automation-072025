namespace Petstore.Models
{
    /// <summary>
    /// Represents a generic API response message.
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Gets or sets the response code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the type of the response.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the message returned by the API.
        /// </summary>
        public string Message { get; set; }
    }
}

