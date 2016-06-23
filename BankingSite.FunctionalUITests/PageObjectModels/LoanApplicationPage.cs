using System.Threading;
using BankingSite.Models;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace BankingSite.FunctionalUITests.PageObjectModels
{
  public class LoanApplicationPage:Page<LoanApplication>
  {
    public T SubmitApplication<T>(LoanApplication application)
      where T : UiComponent, new()
    {
      Input.Model(application);

      return Navigate.To<T>(By.Id("Apply"));
    }
  }
}