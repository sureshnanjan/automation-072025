using OpenQA.Selenium;
using System.Collections.Generic;

namespace DynamicContentPage
{
    /// <summary>
    /// Interface for interacting with the dynamic content page at https://the-internet.herokuapp.com/dynamic_content
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
