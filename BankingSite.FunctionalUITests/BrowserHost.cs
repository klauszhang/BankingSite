using OpenQA.Selenium.Firefox;
using TestStack.Seleno.Configuration;

namespace BankingSite.FunctionalUITests
{
  public static class BrowserHost
  {
    public static readonly SelenoHost Instance = new SelenoHost();
    public static readonly string RootUrl;

    static BrowserHost()
    {
      Instance.Run("BankingSite", 2233, 
        config=>config.WithRouteConfig(RouteConfig.RegisterRoutes)
        .WithRemoteWebDriver(()=>new FirefoxDriver(new FirefoxProfile())));
      RootUrl = Instance.Application.Browser.Url;
    }
  }
}