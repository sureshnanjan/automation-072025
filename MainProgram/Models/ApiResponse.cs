namespace Models
{
    /// <summary>
    /// Describes a general API response.
    /// </summary>
    public class ApiResponse
    {
        public int? Code { get; set; }

        public string Type { get; set; }

        public string Message { get; set; }
    }
}
