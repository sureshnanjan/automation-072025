using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;

class Program
{
    static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        IDynamicLoading loader = new DynamicLoading(driver);

        // Example usage
        loader.NavigateToExample(1);
        loader.ClickStartButton();
        loader.WaitForLoadingToFinish();
        string result = loader.GetResultText();
        Console.WriteLine(result);

        driver.Quit();
    }
}