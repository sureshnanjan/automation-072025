using OpenQA.Selenium;
using System.Collections.Generic;

namespace ShiftingContentPage
{
    /// <summary>
    /// Interface for identifying and interacting with elements on the Shifting Content page.
    /// Allows access to the page header, content links, and description text.
    /// </summary>
    public interface IShiftingContentInterface
    {
        IWebElement PageHeader { get; }

        IList<IWebElement> ContentLinks { get; }

        IWebElement DescriptionText { get; }
    }
}
