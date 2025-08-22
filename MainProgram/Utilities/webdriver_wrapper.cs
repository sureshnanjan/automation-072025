using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace WebAutomation.Core
{
    // Configuration class for WebDriver settings
    public class WebDriverConfig
    {
        public int ImplicitWaitSeconds { get; set; } = 10;
        public int ExplicitWaitSeconds { get; set; } = 30;
        public int PageLoadTimeoutSeconds { get; set; } = 60;
        public int ScriptTimeoutSeconds { get; set; } = 30;
        public bool HeadlessMode { get; set; } = false;
        public string DownloadPath { get; set; } = Path.GetTempPath();
        public Size WindowSize { get; set; } = new Size(1920, 1080);
        public LogLevel LogLevel { get; set; } = LogLevel.Info;
    }

    // Custom exception for web interactions
    public class WebInteractionException : Exception
    {
        public WebInteractionException(string message) : base(message) { }
        public WebInteractionException(string message, Exception innerException) : base(message, innerException) { }
    }

    // Logging levels
    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error
    }

    // Logger interface for dependency injection
    public interface ILogger
    {
        void Log(LogLevel level, string message);
        void LogException(Exception ex, string context = "");
    }

    // Simple console logger implementation
    public class ConsoleLogger : ILogger
    {
        private readonly LogLevel _minLevel;

        public ConsoleLogger(LogLevel minLevel = LogLevel.Info)
        {
            _minLevel = minLevel;
        }

        public void Log(LogLevel level, string message)
        {
            if (level >= _minLevel)
            {
                Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}");
            }
        }

        public void LogException(Exception ex, string context = "")
        {
            Log(LogLevel.Error, $"{context} Exception: {ex.Message}");
            Log(LogLevel.Debug, $"Stack trace: {ex.StackTrace}");
        }
    }

    // Element locator wrapper for better element identification
    public class ElementLocator
    {
        public By By { get; }
        public string Description { get; }
        public int TimeoutSeconds { get; }

        public ElementLocator(By by, string description = "", int timeoutSeconds = 30)
        {
            By = by;
            Description = string.IsNullOrEmpty(description) ? by.ToString() : description;
            TimeoutSeconds = timeoutSeconds;
        }

        // Static factory methods for common locators
        public static ElementLocator ById(string id, string description = "", int timeout = 30)
            => new ElementLocator(By.Id(id), description, timeout);

        public static ElementLocator ByClass(string className, string description = "", int timeout = 30)
            => new ElementLocator(By.ClassName(className), description, timeout);

        public static ElementLocator ByXPath(string xpath, string description = "", int timeout = 30)
            => new ElementLocator(By.XPath(xpath), description, timeout);

        public static ElementLocator ByCss(string cssSelector, string description = "", int timeout = 30)
            => new ElementLocator(By.CssSelector(cssSelector), description, timeout);

        public static ElementLocator ByName(string name, string description = "", int timeout = 30)
            => new ElementLocator(By.Name(name), description, timeout);

        public static ElementLocator ByTag(string tagName, string description = "", int timeout = 30)
            => new ElementLocator(By.TagName(tagName), description, timeout);

        public static ElementLocator ByLinkText(string linkText, string description = "", int timeout = 30)
            => new ElementLocator(By.LinkText(linkText), description, timeout);

        public static ElementLocator ByPartialLinkText(string partialLinkText, string description = "", int timeout = 30)
            => new ElementLocator(By.PartialLinkText(partialLinkText), description, timeout);
    }

    // Main WebDriver wrapper class
    public class WebDriverWrapper : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly Actions _actions;
        private readonly ILogger _logger;
        private readonly WebDriverConfig _config;
        private bool _disposed = false;

        public IWebDriver Driver => _driver;
        public WebDriverWait Wait => _wait;
        public Actions Actions => _actions;

        public WebDriverWrapper(string browserType = "chrome", WebDriverConfig config = null, ILogger logger = null)
        {
            _config = config ?? new WebDriverConfig();
            _logger = logger ?? new ConsoleLogger(_config.LogLevel);

            try
            {
                _driver = CreateDriver(browserType.ToLower());
                ConfigureDriver();
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_config.ExplicitWaitSeconds));
                _actions = new Actions(_driver);

                _logger.Log(LogLevel.Info, $"WebDriver initialized successfully with {browserType}");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, "Failed to initialize WebDriver");
                throw new WebInteractionException("Failed to initialize WebDriver", ex);
            }
        }

        private IWebDriver CreateDriver(string browserType)
        {
            return browserType switch
            {
                "chrome" => CreateChromeDriver(),
                "firefox" => CreateFirefoxDriver(),
                "edge" => CreateEdgeDriver(),
                _ => throw new ArgumentException($"Unsupported browser type: {browserType}")
            };
        }

        private IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            if (_config.HeadlessMode) options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument($"--window-size={_config.WindowSize.Width},{_config.WindowSize.Height}");

            var prefs = new Dictionary<string, object>
            {
                ["download.default_directory"] = _config.DownloadPath,
                ["download.prompt_for_download"] = false,
                ["profile.default_content_settings.popups"] = 0
            };
            options.AddUserProfilePreference("prefs", prefs);

            return new ChromeDriver(options);
        }

        private IWebDriver CreateFirefoxDriver()
        {
            var options = new FirefoxOptions();
            if (_config.HeadlessMode) options.AddArgument("--headless");

            var profile = new FirefoxProfile();
            profile.SetPreference("browser.download.dir", _config.DownloadPath);
            profile.SetPreference("browser.download.folderList", 2);
            profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream");
            options.Profile = profile;

            return new FirefoxDriver(options);
        }

        private IWebDriver CreateEdgeDriver()
        {
            var options = new EdgeOptions();
            if (_config.HeadlessMode) options.AddArgument("--headless");
            options.AddArgument($"--window-size={_config.WindowSize.Width},{_config.WindowSize.Height}");

            return new EdgeDriver(options);
        }

        private void ConfigureDriver()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_config.ImplicitWaitSeconds);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_config.PageLoadTimeoutSeconds);
            _driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(_config.ScriptTimeoutSeconds);

            if (!_config.HeadlessMode)
            {
                _driver.Manage().Window.Size = _config.WindowSize;
            }
        }

        // Navigation methods
        public void NavigateTo(string url)
        {
            try
            {
                _logger.Log(LogLevel.Info, $"Navigating to: {url}");
                _driver.Navigate().GoToUrl(url);
                WaitForPageLoad();
                _logger.Log(LogLevel.Info, $"Successfully navigated to: {url}");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to navigate to {url}");
                throw new WebInteractionException($"Failed to navigate to {url}", ex);
            }
        }

        public void NavigateBack()
        {
            try
            {
                _logger.Log(LogLevel.Info, "Navigating back");
                _driver.Navigate().Back();
                WaitForPageLoad();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, "Failed to navigate back");
                throw new WebInteractionException("Failed to navigate back", ex);
            }
        }

        public void NavigateForward()
        {
            try
            {
                _logger.Log(LogLevel.Info, "Navigating forward");
                _driver.Navigate().Forward();
                WaitForPageLoad();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, "Failed to navigate forward");
                throw new WebInteractionException("Failed to navigate forward", ex);
            }
        }

        public void RefreshPage()
        {
            try
            {
                _logger.Log(LogLevel.Info, "Refreshing page");
                _driver.Navigate().Refresh();
                WaitForPageLoad();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, "Failed to refresh page");
                throw new WebInteractionException("Failed to refresh page", ex);
            }
        }

        // Element finding methods
        public IWebElement FindElement(ElementLocator locator)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Finding element: {locator.Description}");
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(locator.TimeoutSeconds));
                var element = wait.Until(driver => driver.FindElement(locator.By));
                _logger.Log(LogLevel.Debug, $"Found element: {locator.Description}");
                return element;
            }
            catch (WebDriverTimeoutException ex)
            {
                _logger.LogException(ex, $"Timeout finding element: {locator.Description}");
                throw new WebInteractionException($"Element not found within {locator.TimeoutSeconds} seconds: {locator.Description}", ex);
            }
        }

        public ReadOnlyCollection<IWebElement> FindElements(ElementLocator locator)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Finding elements: {locator.Description}");
                var elements = _driver.FindElements(locator.By);
                _logger.Log(LogLevel.Debug, $"Found {elements.Count} elements: {locator.Description}");
                return elements;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to find elements: {locator.Description}");
                throw new WebInteractionException($"Failed to find elements: {locator.Description}", ex);
            }
        }

        public bool IsElementPresent(ElementLocator locator, int timeoutSeconds = 5)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
                wait.Until(driver => driver.FindElement(locator.By));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool IsElementVisible(ElementLocator locator, int timeoutSeconds = 5)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
                //var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator.By));
                bool? element = null;
                return element != null;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool IsElementClickable(ElementLocator locator, int timeoutSeconds = 5)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
                bool element = false;  //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator.By));

                return element;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        // Click methods
        public void Click(ElementLocator locator)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Clicking element: {locator.Description}");
                var element = WaitForClickable(locator);
                ScrollToElement(element);
                element.Click();
                _logger.Log(LogLevel.Debug, $"Clicked element: {locator.Description}");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to click element: {locator.Description}");
                throw new WebInteractionException($"Failed to click element: {locator.Description}", ex);
            }
        }

        public void DoubleClick(ElementLocator locator)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Double clicking element: {locator.Description}");
                var element = WaitForClickable(locator);
                ScrollToElement(element);
                _actions.DoubleClick(element).Perform();
                _logger.Log(LogLevel.Debug, $"Double clicked element: {locator.Description}");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to double click element: {locator.Description}");
                throw new WebInteractionException($"Failed to double click element: {locator.Description}", ex);
            }
        }

        public void RightClick(ElementLocator locator)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Right clicking element: {locator.Description}");
                var element = WaitForClickable(locator);
                ScrollToElement(element);
                _actions.ContextClick(element).Perform();
                _logger.Log(LogLevel.Debug, $"Right clicked element: {locator.Description}");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to right click element: {locator.Description}");
                throw new WebInteractionException($"Failed to right click element: {locator.Description}", ex);
            }
        }

        public void ClickWithJavaScript(ElementLocator locator)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"JavaScript clicking element: {locator.Description}");
                var element = FindElement(locator);
                ExecuteJavaScript("arguments[0].click();", element);
                _logger.Log(LogLevel.Debug, $"JavaScript clicked element: {locator.Description}");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to JavaScript click element: {locator.Description}");
                throw new WebInteractionException($"Failed to JavaScript click element: {locator.Description}", ex);
            }
        }

        // Text input methods
        public void SendKeys(ElementLocator locator, string text, bool clearFirst = true)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Sending keys to element: {locator.Description}");
                var element = WaitForClickable(locator);
                ScrollToElement(element);

                if (clearFirst)
                {
                    element.Clear();
                }

                element.SendKeys(text);
                _logger.Log(LogLevel.Debug, $"Sent keys to element: {locator.Description}");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to send keys to element: {locator.Description}");
                throw new WebInteractionException($"Failed to send keys to element: {locator.Description}", ex);
            }
        }

        public void SendKeysSlowly(ElementLocator locator, string text, int delayMs = 100, bool clearFirst = true)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Sending keys slowly to element: {locator.Description}");
                var element = WaitForClickable(locator);
                ScrollToElement(element);

                if (clearFirst)
                {
                    element.Clear();
                }

                foreach (char c in text)
                {
                    element.SendKeys(c.ToString());
                    Thread.Sleep(delayMs);
                }
                _logger.Log(LogLevel.Debug, $"Sent keys slowly to element: {locator.Description}");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to send keys slowly to element: {locator.Description}");
                throw new WebInteractionException($"Failed to send keys slowly to element: {locator.Description}", ex);
            }
        }

        public void ClearText(ElementLocator locator)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Clearing text from element: {locator.Description}");
                var element = FindElement(locator);
                element.Clear();
                _logger.Log(LogLevel.Debug, $"Cleared text from element: {locator.Description}");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to clear text from element: {locator.Description}");
                throw new WebInteractionException($"Failed to clear text from element: {locator.Description}", ex);
            }
        }

        // Text retrieval methods
        public string GetText(ElementLocator locator)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Getting text from element: {locator.Description}");
                var element = FindElement(locator);
                var text = element.Text;
                _logger.Log(LogLevel.Debug, $"Got text from element: {locator.Description} - '{text}'");
                return text;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to get text from element: {locator.Description}");
                throw new WebInteractionException($"Failed to get text from element: {locator.Description}", ex);
            }
        }

        public string GetAttribute(ElementLocator locator, string attributeName)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Getting attribute '{attributeName}' from element: {locator.Description}");
                var element = FindElement(locator);
                var value = element.GetAttribute(attributeName);
                _logger.Log(LogLevel.Debug, $"Got attribute '{attributeName}' from element: {locator.Description} - '{value}'");
                return value;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to get attribute '{attributeName}' from element: {locator.Description}");
                throw new WebInteractionException($"Failed to get attribute '{attributeName}' from element: {locator.Description}", ex);
            }
        }

        public string GetCssValue(ElementLocator locator, string propertyName)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Getting CSS value '{propertyName}' from element: {locator.Description}");
                var element = FindElement(locator);
                var value = element.GetCssValue(propertyName);
                _logger.Log(LogLevel.Debug, $"Got CSS value '{propertyName}' from element: {locator.Description} - '{value}'");
                return value;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to get CSS value '{propertyName}' from element: {locator.Description}");
                throw new WebInteractionException($"Failed to get CSS value '{propertyName}' from element: {locator.Description}", ex);
            }
        }

        // Dropdown/Select methods
        public void SelectByText(ElementLocator locator, string text)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Selecting by text '{text}' from dropdown: {locator.Description}");
                var element = FindElement(locator);
                var select = new SelectElement(element);
                select.SelectByText(text);
                _logger.Log(LogLevel.Debug, $"Selected by text '{text}' from dropdown: {locator.Description}");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to select by text '{text}' from dropdown: {locator.Description}");
                throw new WebInteractionException($"Failed to select by text '{text}' from dropdown: {locator.Description}", ex);
            }
        }

        public void SelectByValue(ElementLocator locator, string value)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Selecting by value '{value}' from dropdown: {locator.Description}");
                var element = FindElement(locator);
                var select = new SelectElement(element);
                select.SelectByValue(value);
                _logger.Log(LogLevel.Debug, $"Selected by value '{value}' from dropdown: {locator.Description}");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to select by value '{value}' from dropdown: {locator.Description}");
                throw new WebInteractionException($"Failed to select by value '{value}' from dropdown: {locator.Description}", ex);
            }
        }

        public void SelectByIndex(ElementLocator locator, int index)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Selecting by index '{index}' from dropdown: {locator.Description}");
                var element = FindElement(locator);
                var select = new SelectElement(element);
                select.SelectByIndex(index);
                _logger.Log(LogLevel.Debug, $"Selected by index '{index}' from dropdown: {locator.Description}");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to select by index '{index}' from dropdown: {locator.Description}");
                throw new WebInteractionException($"Failed to select by index '{index}' from dropdown: {locator.Description}", ex);
            }
        }

        public List<string> GetAllSelectOptions(ElementLocator locator)
        {
            try
            {
                _logger.Log(LogLevel.Debug, $"Getting all options from dropdown: {locator.Description}");
                var element = FindElement(locator);
                var select = new SelectElement(element);
                var options = select.Options.Select(option => option.Text).ToList();
                _logger.Log(LogLevel.Debug, $"Got {options.Count} options from dropdown: {locator.Description}");
                return options;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to get options from dropdown: {locator.Description}");
                throw new WebInteractionException($"Failed to get options from dropdown: {locator.Description}", ex);
            }
        }

        // Scroll methods
        public void ScrollToElement(IWebElement element)
        {
            try
            {
                ExecuteJavaScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", element);
                Thread.Sleep(500); // Wait for smooth scroll
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, "Failed to scroll to element");
                throw new WebInteractionException("Failed to scroll to element", ex);
            }
        }

        public void ScrollToElement(ElementLocator locator)
        {
            var element = FindElement(locator);
            ScrollToElement(element);
        }

        public void ScrollToTop()
        {
            ExecuteJavaScript("window.scrollTo(0, 0);");
        }

        public void ScrollToBottom()
        {
            ExecuteJavaScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        public void ScrollBy(int x, int y)
        {
            ExecuteJavaScript($"window.scrollBy({x}, {y});");
        }

        // Wait methods
        public IWebElement? WaitForVisible(ElementLocator locator)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(locator.TimeoutSeconds));
                //return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator.By));
                return null;
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new WebInteractionException($"Element not visible within {locator.TimeoutSeconds} seconds: {locator.Description}", ex);
            }
        }

        public IWebElement WaitForClickable(ElementLocator locator)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(locator.TimeoutSeconds));
                //return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator.By));
                return null;
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new WebInteractionException($"Element not clickable within {locator.TimeoutSeconds} seconds: {locator.Description}", ex);
            }
        }

        public void WaitForElementToDisappear(ElementLocator locator, int timeoutSeconds = 30)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator.By));
                //return null ;
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new WebInteractionException($"Element did not disappear within {timeoutSeconds} seconds: {locator.Description}", ex);
            }
        }

        public void WaitForPageLoad(int timeoutSeconds = 30)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
                wait.Until(driver => ExecuteJavaScript("return document.readyState").Equals("complete"));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new WebInteractionException($"Page did not load within {timeoutSeconds} seconds", ex);
            }
        }

        public void WaitForText(ElementLocator locator, string expectedText, int timeoutSeconds = 30)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
                wait.Until(driver => FindElement(locator).Text.Contains(expectedText));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new WebInteractionException($"Expected text '{expectedText}' not found within {timeoutSeconds} seconds: {locator.Description}", ex);
            }
        }

        // JavaScript execution
        public object ExecuteJavaScript(string script, params object[] args)
        {
            try
            {
                var jsExecutor = (IJavaScriptExecutor)_driver;
                return jsExecutor.ExecuteScript(script, args);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to execute JavaScript: {script}");
                throw new WebInteractionException($"Failed to execute JavaScript: {script}", ex);
            }
        }

        public T ExecuteJavaScript<T>(string script, params object[] args)
        {
            var result = ExecuteJavaScript(script, args);
            return (T)result;
        }

        // Window and frame handling
        public void SwitchToWindow(string windowHandle)
        {
            try
            {
                _driver.SwitchTo().Window(windowHandle);
                _logger.Log(LogLevel.Debug, $"Switched to window: {windowHandle}");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to switch to window: {windowHandle}");
                throw new WebInteractionException($"Failed to switch to window: {windowHandle}", ex);
            }
        }

        public void SwitchToFrame(ElementLocator locator)
        {
            try
            {
                var frame = FindElement(locator);
                _driver.SwitchTo().Frame(frame);
                _logger.Log(LogLevel.Debug, $"Switched to frame: {locator.Description}");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, $"Failed to switch to frame: {locator.Description}");
                throw new WebInteractionException($"Failed to switch to frame: {locator.Description}", ex);
            }
        }

        public void SwitchToDefaultContent()
        {
            try
            {
                _driver.SwitchTo().DefaultContent();
                _logger.Log(LogLevel.Debug, "Switched to default content");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, "Failed to switch to default content");
                throw new WebInteractionException("Failed to switch to default content", ex);
            }
        }

        // Alert handling
        public void AcceptAlert()
        {
            try
            {
                var alert = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                alert.Accept();
                _logger.Log(LogLevel.Debug, "Accepted alert");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, "Failed to accept alert");
                throw new WebInteractionException("Failed to accept alert", ex);
            }
        }

        public void DismissAlert()
        {
            try
            {
                var alert = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                alert.Dismiss();
                _logger.Log(LogLevel.Debug, "Dismissed alert");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, "Failed to dismiss alert");
                throw new WebInteractionException("Failed to dismiss alert", ex);
            }
        }

        public string GetAlertText()
        {
            try
            {
                var alert = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                var text = alert.Text;
                _logger.Log(LogLevel.Debug, $"Alert text: {text}");
                return text;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, "Failed to get alert text");
                throw new WebInteractionException("Failed to get alert text", ex);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}