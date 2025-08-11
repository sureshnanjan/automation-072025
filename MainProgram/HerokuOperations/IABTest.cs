<<<<<<< HEAD
﻿/*
<<<<<<< HEAD
* IABTest Interface
* 
* This interface defines the operations for verifying and controlling A/B Test content 
* on the HerokuApp site (https://the-internet.herokuapp.com/abtest).
* 
* Author: Teja Reddy
* Created: August 2025
* License: For educational or internal use only.
* 
* © 2025 Teja Reddy. All rights reserved.
*/
=======
 * IABTest Interface
 * 
 * This interface defines the operations for verifying and controlling A/B Test content 
 * on the HerokuApp site (https://the-internet.herokuapp.com/abtest).
 * 
 * Author: Teja Reddy
 * Created: August 2025
 * License: For educational or internal use only.
 * 
 * © 2025 Teja Reddy. All rights reserved.
 */
>>>>>>> 39d9ac82c94ebdaa9a086c8441be75d73dc53ddb

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Interface for interacting with the A/B Testing page on HerokuApp.
    /// </summary>
    public interface IABTest
    {
        /// <summary>
        /// Gets the main title of the A/B Test page.
        /// </summary>
        /// <returns>The title string.</returns>
        string GetTitle();

        /// <summary>
        /// Gets the description or body content shown under the title.
        /// </summary>
        /// <returns>The description string.</returns>
        string GetDescription();

        /// <summary>
        /// Disables the A/B test by navigating with a query parameter or custom logic.
        /// </summary>
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    public interface IABTest
    {
        string GetTitle();
        string GetDescription();
>>>>>>> e61a7b07dfaee872f7c92bafa503b62494e5548e
        void DisableABTest();
    }
}
