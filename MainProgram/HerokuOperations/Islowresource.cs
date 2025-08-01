using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    public interface Islowresource
    {
      
        /// Gets the page title (e.g., "Slow Resources").  
        string GetTitle();

        /// Gets the static description text shown on the page.
        string GetDescription();

    }
}  