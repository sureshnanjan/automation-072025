using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;

namespace HerokuAppScenarios
{
    [TestFixture]
    public class RedirectScenarios
    {
        

        [Test]
        public void GetTitle_ShouldReturnCorrectText()
        {
            IRedirect redirect;
            string title = redirect.GetTitle();
            Assert.That(title, Is.EqualTo("Redirection"));
        }

        [Test]        
        public void GetParagraphText_ShouldContainExpectedMessage()
        {
            string paragraph = redirect.GetParagraphText();
            StringAssert.Contains("redirect", paragraph); // keyword match
        }

        [Test]
        public void ClickhereLink_ShouldRedirectToStatusCodesPage()
        {
            redirect.ClickhereLink();
            Assert.That(driver.Url, Does.Contain("/status_codes"));
        }

        
    }
}


/*
 Type of Testcases to be written
1 . GetTitle() - heading (Redirect link)
2. GetContent() - get the content of the  page
3. GetLogo() - if logo present or not .
4.ClickHere() - link to redirect to next page.
  4.1 Clickhere() - should redirect to the next page
  4.2 GetTitleStatusCode() - title of status code
  4.3 GetContentStatusCode() - paragraph 
  4.4 Get200() - redirect to 200 content page


 * \
