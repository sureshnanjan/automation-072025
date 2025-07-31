using OpenQA.Selenium;
using System.Collections.Generic;

namespace DynamicContentPage
{
    /// <summary>
    /// Interface for identifying and interacting with elements on the dynamic content page.
    /// Provides access to headers, rows, images, texts, and footer elements.
    /// </summary>
    public interface IDynamicContentInterface
    {
        IWebElement PageHeader { get; }

        IList<IWebElement> ContentRows { get; }

        IWebElement GetImageElementInRow(int rowIndex);

        IWebElement GetTextElementInRow(int rowIndex);

        IWebElement ExampleText { get; }

        IWebElement PoweredByText { get; }
    }
}
