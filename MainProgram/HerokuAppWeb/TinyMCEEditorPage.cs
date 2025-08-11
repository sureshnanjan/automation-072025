using System;
using System.Linq;
using OpenQA.Selenium;
using WebAutomation.Core; // use your wrapper & ElementLocator

namespace HerokuOperations
{
    /// <summary>
    /// Implements interactions with the TinyMCE WYSIWYG editor on the HerokuApp test page,
    /// aligned to WebAutomation.Core.WebDriverWrapper and ElementLocator.
    /// </summary>
    public class TinyMCEEditorPage : ITinyMCEEditorPage
    {
        private readonly WebDriverWrapper _web;
        private const string PageUrl = "https://the-internet.herokuapp.com/tinymce";

        // ───────────── Locators ─────────────
        private static readonly ElementLocator IframeLocator =
            ElementLocator.ByCss("#mce_0_ifr, iframe.tox-edit-area__iframe", "TinyMCE editor iframe", timeout: 10);

        private static readonly ElementLocator EditorBody =
            ElementLocator.ByCss("#tinymce", "TinyMCE editable body", timeout: 10);

        private static readonly ElementLocator Footer =
            ElementLocator.ByCss("#page-footer", "Footer container", timeout: 10);

        private static readonly ElementLocator FooterLink =
            ElementLocator.ByCss("#page-footer a", "Footer link", timeout: 10);

        private static readonly ElementLocator GitHubRibbonImg =
            ElementLocator.ByCss("a[href*='github.com'] img", "GitHub ribbon image", timeout: 10);

        public TinyMCEEditorPage(WebDriverWrapper web)
        {
            _web = web ?? throw new ArgumentNullException(nameof(web));
        }

        // ───────────── NAVIGATION & FRAME METHODS ─────────────
        public void GotoPage()
        {
            _web.NavigateTo(PageUrl);
        }

        public void SwitchToEditorFrame()
        {
            _web.SwitchToFrame(IframeLocator);
        }

        public void SwitchToMainContent()
        {
            _web.SwitchToDefaultContent();
        }

        // Helper to run actions inside the editor iframe safely
        private void InEditorFrame(Action action)
        {
            _web.SwitchToFrame(IframeLocator);
            try
            {
                action();
            }
            finally
            {
                _web.SwitchToDefaultContent();
            }
        }

        // ───────────── TEXT EDITING METHODS ─────────────
        public void ClearEditorContent()
        {
            InEditorFrame(() =>
            {
                var body = _web.FindElement(EditorBody);
                body.Clear();
            });
        }

        public void EnterTextInEditor(string text)
        {
            if (text is null) text = string.Empty;

            InEditorFrame(() =>
            {
                var body = _web.FindElement(EditorBody);
                body.Clear();            // direct Clear/SendKeys to avoid wrapper.SendKeys (which uses a stubbed wait)
                body.SendKeys(text);
            });
        }

        public void AppendTextInEditor(string text)
        {
            if (text is null) return;

            InEditorFrame(() =>
            {
                var body = _web.FindElement(EditorBody);
                body.SendKeys(text);
            });
        }

        public string GetEditorContent()
        {
            string content = string.Empty;
            InEditorFrame(() =>
            {
                var body = _web.FindElement(EditorBody);
                content = body.Text?.Trim() ?? string.Empty;
            });
            return content;
        }

        // ───────────── FOOTER VALIDATION METHODS ─────────────
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

        // ───────────── PLACEHOLDER METHODS (NOT IMPLEMENTED IN DEMO UI) ─────────────
        public void ApplyBold() => throw new NotImplementedException();
        public void ApplyItalic() => throw new NotImplementedException();
        public void ApplyUnderline() => throw new NotImplementedException();
        public bool IsBoldApplied() => throw new NotImplementedException();
        public bool IsItalicApplied() => throw new NotImplementedException();
        public bool IsUnderlineApplied() => throw new NotImplementedException();
        public void AlignLeft() => throw new NotImplementedException();
        public void AlignCenter() => throw new NotImplementedException();
        public void AlignRight() => throw new NotImplementedException();
        public void AlignJustify() => throw new NotImplementedException();
        public string GetCurrentTextAlignment() => throw new NotImplementedException();
        public void SelectParagraphFormat(string format) => throw new NotImplementedException();
        public string GetCurrentParagraphFormat() => throw new NotImplementedException();
        public void OpenFileMenu() => throw new NotImplementedException();
        public bool IsFileMenuVisible() => throw new NotImplementedException();
        public void OpenEditMenu() => throw new NotImplementedException();
        public void PerformUndo() => throw new NotImplementedException();
        public void PerformRedo() => throw new NotImplementedException();
        public void CutText() => throw new NotImplementedException();
        public void CopyText() => throw new NotImplementedException();
        public void PasteText() => throw new NotImplementedException();
        public void OpenViewMenu() => throw new NotImplementedException();
        public void ToggleFullscreen() => throw new NotImplementedException();
        public bool IsFullscreenEnabled() => throw new NotImplementedException();
        public void OpenFormatMenu() => throw new NotImplementedException();
        public void ClearFormatting() => throw new NotImplementedException();
    }
}
