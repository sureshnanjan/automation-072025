using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automator
{
    public class FirefoxAutomatorWI : IBrowsable, IClose, INavigate
    {
        public void ClickElement(string elementId)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void EnterText(string elementId, string text)
        {
            throw new NotImplementedException();
        }

        public string GetCurrentURL()
        {
            throw new NotImplementedException();
        }

        public string GetElementText(string elementId)
        {
            throw new NotImplementedException();
        }

        public string GetTitle()
        {
            throw new NotImplementedException();
        }

        public void GotoURL(string url)
        {
            throw new NotImplementedException();
        }

        public bool IsElementPresent(string elementId)
        {
            throw new NotImplementedException();
        }

        public void Launch()
        {
            throw new NotImplementedException();
        }
    }
}
