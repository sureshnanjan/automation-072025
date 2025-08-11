using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using WebAutomation.Core;

namespace HerokuOperations
{
    public class StatusCodesPage : IStatusCodes
    {
        private readonly WebDriverWrapper _wrapper;
        private readonly string _pageUrl = "https://the-internet.herokuapp.com/status_codes";

        public StatusCodesPage(WebDriverWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        private ElementLocator StatusCodeLinkLocator(string code) =>
            ElementLocator.ByLinkText(code, $"Status code link {code}");

        public string GetPageTitle()
        {
            return _wrapper.GetText(ElementLocator.ByCss("div.example h3", "Page heading"));
        }

        public string GetDescriptionText()
        {
            return _wrapper.GetText(ElementLocator.ByCss("div.example p", "Description paragraph"));
        }

        public string GetReferenceLinkText()
        {
            return _wrapper.GetText(ElementLocator.ByCss("div.example p a", "Reference link text"));
        }

        public string GetReferenceLinkHref()
        {
            return _wrapper.GetAttribute(ElementLocator.ByCss("div.example p a", "Reference link"), "href");
        }

        public List<string> GetAllStatusCodeLinks()
        {
            var elements = _wrapper.FindElements(ElementLocator.ByCss("ul li a", "All status code links"));
            return elements.Select(e => e.Text.Trim()).ToList();
        }

        public bool IsStatusCodeClickable(int statusCode)
        {
            return _wrapper.IsElementClickable(StatusCodeLinkLocator(statusCode.ToString()));
        }

        public void ClickStatusCode(string code)
        {
            _wrapper.Click(StatusCodeLinkLocator(code));
        }

        public void ClickStatusCode(int code)
        {
            ClickStatusCode(code.ToString());
        }

        public string GetStatusMessage()
        {
            // On the details page, the message appears in <div class="example"> <p> ... </p>
            return _wrapper.GetText(ElementLocator.ByCss("div.example p", "Status message"));
        }

        public void NavigateBack()
        {
            _wrapper.NavigateBack();
        }

        public string GetCurrentUrl()
        {
            return _wrapper.Driver.Url;
        }

        public List<string> GetStatusCodeLinks()
        {
            // Same as GetAllStatusCodeLinks but keeping both methods as per interface
            return GetAllStatusCodeLinks();
        }
    }
}
