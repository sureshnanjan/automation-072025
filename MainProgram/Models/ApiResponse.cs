
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Represents a standard API response structure containing status code, type, and message.
    /// </summary>
    internal class ApiResponse
    {
        /// <summary>
        /// The response status code, such as HTTP 200 (OK) or 400 (Bad Request).
        /// </summary>
        public int? Code { get; set; }

        /// <summary>
        /// A short description or category of the response (e.g., "success", "error").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A detailed message from the server explaining the result of the API call.
        /// </summary>
        /// 
        public string Message { get; set; }
    }

}
