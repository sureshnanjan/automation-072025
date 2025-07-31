using OpenQA.Selenium;
using System.Collections.Generic;

namespace ShiftingContentPage
{
    interface IShiftingContentInterface
    {
        IWebElement PageHeader { get; }

        IList<IWebElement> ContentLinks { get; }

        IWebElement DescriptionText { get; }
    }
}
