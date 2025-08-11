using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using WebAutomation.Core; // use your wrapper & ElementLocator

namespace HerokuOperations
{
    /// <summary>
    /// Automation for https://the-internet.herokuapp.com/add_remove_elements/
    /// Aligned with WebAutomation.Core.WebDriverWrapper and ElementLocator.
    /// </summary>
    public class AddRemoveElementsPage : IAddRemoveElements
    {
        private readonly WebDriverWrapper _web;
        private const string PageUrl = "https://the-internet.herokuapp.com/add_remove_elements/";

        // ───────────── Locators ─────────────
        private static readonly ElementLocator AddElementBtn =
            ElementLocator.ByCss("button[onclick='addElement()']", "Add Element button", timeout: 10);

        private static readonly ElementLocator DeleteButtons =
            ElementLocator.ByCss("button.added-manually", "Delete buttons", timeout: 5);

        private static readonly ElementLocator Footer =
            ElementLocator.ByCss("#page-footer", "Footer container", timeout: 10);

        private static readonly ElementLocator FooterLink =
            ElementLocator.ByCss("#page-footer a", "Footer link", timeout: 10);

        private static readonly ElementLocator GitHubRibbonImg =
            ElementLocator.ByCss("a[href*='github.com'] img", "GitHub ribbon image", timeout: 10);

        public AddRemoveElementsPage(WebDriverWrapper web)
        {
            _web = web ?? throw new ArgumentNullException(nameof(web));
        }

        // ───────────── REAL WORKING INTERACTIONS ─────────────
        public void GotoPage()
        {
            _web.NavigateTo(PageUrl);
        }

        public void ClickAddElement()
        {
            var btn = _web.FindElement(AddElementBtn);
            _web.ScrollToElement(btn);
            btn.Click();
        }

        public int CountDeleteButtons()
        {
            var els = _web.FindElements(DeleteButtons);
            return els?.Count ?? 0;
        }

        public bool IsDeleteButtonPresent()
        {
            return CountDeleteButtons() > 0;
        }

        public void ClickDeleteButton()
        {
            var buttons = _web.FindElements(DeleteButtons);
            if (buttons.Count > 0)
            {
                var first = buttons[0];
                _web.ScrollToElement(first);
                first.Click();
            }
        }

        public void RemoveAllDeleteButtons()
        {
            // Copy to list first because clicking removes elements from DOM
            var buttons = new List<IWebElement>(_web.FindElements(DeleteButtons));
            foreach (var btn in buttons)
            {
                try
                {
                    _web.ScrollToElement(btn);
                    btn.Click();
                }
                catch (StaleElementReferenceException)
                {
                    // Element already removed—safe to ignore
                }
            }
        }

        public bool IsFooterPoweredByVisible()
        {
            try
            {
                var footer = _web.FindElement(Footer);
                if (!footer.Displayed) return false;

                var link = _web.FindElement(FooterLink);
                var text = link.Text?.Trim() ?? string.Empty;
                return link.Displayed &&
                       text.IndexOf("Powered by Elemental Selenium", StringComparison.OrdinalIgnoreCase) >= 0;
            }
            catch (WebInteractionException)
            {
                return false;
            }
        }

        public bool IsGitHubRibbonVisible()
        {
            try
            {
                var img = _web.FindElement(GitHubRibbonImg);
                return img.Displayed && img.Enabled;
            }
            catch (WebInteractionException)
            {
                return false;
            }
        }
    }
}
