using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace BankingSite.FunctionalUITests.PageObjectModels
{
  public class DeclinedPage : Page
  {
    public string DeclinedMessage => Find.Element(By.Id("declineMessage")).Text;
  }
}
