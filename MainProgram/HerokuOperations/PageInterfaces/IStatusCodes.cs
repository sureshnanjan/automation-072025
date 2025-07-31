/*
* Copyright (c) 2025 Gayathri Thalapathi
* 
* This interface is part of the HerokuOperations project.
* It defines the contract for interacting with the "Status Codes" page
* on the-internet.herokuapp.com.
* 
* Licensed under the MIT License. You may obtain a copy of the License at
* https://opensource.org/licenses/MIT
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HerokuOperations.PageInterfaces
{
    /// <summary>
    /// Represents interactions with the Status Codes page
    /// on https://the-internet.herokuapp.com/status_codes.
    /// </summary>
    public interface IStatusCodes
    {
        /// <summary>
        /// Clicks on the link corresponding to a specific HTTP status code.
        /// </summary>
        /// <param name="code">The HTTP status code to click (e.g., "200", "301", "404", "500").</param>
        void ClickStatusCode(string code);

        /// <summary>
        /// Retrieves the message displayed after clicking a status code link.
        /// </summary>
        /// <returns>A string containing the explanation of the selected status code.</returns>
        string GetStatusMessage();
    }
}