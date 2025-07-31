using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automator
{
    public interface IBrowsable
    {
        void Launch();
        //void GotoURL(string url);
        //void Close();
        string GetTitle();
        string GetCurrentURL();
        bool IsElementPresent(string elementId);
        void ClickElement(string elementId);
        void EnterText(string elementId, string text);
        string GetElementText(string elementId);
    }

}
