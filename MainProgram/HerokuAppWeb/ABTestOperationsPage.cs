using System;
using System.Linq;
using OpenQA.Selenium;
using WebAutomation.Core; // <-- uses your wrapper & ElementLocator

namespace HerokuOperations
{
    /// <summary>
    /// Implementation of IABTest to interact with the A/B Testing page.
    /// Aligned with WebAutomation.Core WebDriverWrapper & ElementLocator.
    /// </summary>
    public class ABTestOperationsPage : IABTest
    {
        private readonly WebDriverWrapper _web;

        // ───────────── Locators ─────────────
        private static readonly ElementLocator TitleH3 =
            ElementLocator.ByCss("#content h3", "A/B Test title", timeout: 10);

        private static readonly ElementLocator DescriptionP =
            ElementLocator.ByCss("#content p", "A/B Test description paragraph", timeout: 10);

        private static readonly ElementLocator FooterContainer =
            ElementLocator.ByCss("#page-footer", "Footer container", timeout: 10);

        private static readonly ElementLocator FooterPoweredByLink =
            ElementLocator.ByCss("#page-footer a", "Footer 'Powered by Elemental Selenium' link", timeout: 10);

        private static readonly ElementLocator GitHubRibbonImg =
            ElementLocator.ByCss("a[href*='github.com'] img", "GitHub fork ribbon image", timeout: 10);

        public ABTestOperationsPage(WebDriverWrapper web)
        {
            _web = web ?? throw new ArgumentNullException(nameof(web));
        }

        public string GetTitle()
        {
            try
            {
                // Wait + get trimmed text via wrapper
                var text = _web.GetText(TitleH3);
                return text?.Trim() ?? string.Empty;
            }
            catch (WebInteractionException)
            {
                // Fallback: return empty — let test assert appropriately
                return string.Empty;
            }
        }

        public string GetDescription()
        {
            try
            {
                // Some variants show multiple <p>; prefer first non-empty
                var all = _web.FindElements(DescriptionP);
                var first = all.FirstOrDefault(e => !string.IsNullOrWhiteSpace(e.Text));
                return first?.Text.Trim() ?? string.Empty;
            }
            catch (WebInteractionException)
            {
                return string.Empty;
            }
        }

        public bool IsFooterPoweredByVisible()
        {
            try
            {
                // Ensure footer exists; then verify the link text contains the phrase
                var footer = _web.FindElement(FooterContainer);
                if (!footer.Displayed) return false;

                var link = _web.FindElement(FooterPoweredByLink);
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
                // Don’t rely on wrapper’s IsElementVisible (stubbed in your copy) — use FindElement with wait
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
