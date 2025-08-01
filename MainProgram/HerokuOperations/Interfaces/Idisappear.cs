using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations.Interfaces
{
    public interface Idisappear
    {
    
        /// Gets the main title of the page.
        string GetTitle();

        /// Gets the subtitle or description under the title.
        string GetSubTitle();

      
        /// Gets the GitHub repository URL linked on the page.
        string GetRepoUrl();

        /// Returns the list of currently visible navigation elements (e.g., Home, About, Contact Us, etc.).
        /// This list may vary on each page load due to disappearing behavior.
        
        string[] GetVisibleNavigationItems();
    }
}
