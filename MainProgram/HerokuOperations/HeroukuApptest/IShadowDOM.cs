using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    internal interface ShadowDOM
    {
            
        // Gets the text content of the first shadow host's paragraph (e.g., "My default text")
        string GetFirstShadowHostText();

        // Gets the text content of the second shadow host's paragraph (e.g., "Let's have some different text!")
        string GetSecondShadowHostText();

        // Gets the text inside any nested shadow DOM element
        string GetNestedShadowText();
    }
}
    
