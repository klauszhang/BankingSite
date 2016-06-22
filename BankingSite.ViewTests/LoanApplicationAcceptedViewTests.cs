using System.Collections;
using BankingSite.Models;
using NUnit.Framework;
using RazorGenerator.Testing;

namespace BankingSite.ViewTests
{
  //[TestFixture]
  public class LoanApplicationAcceptedViewTests
  {
    //[Test]
    public void ShouldRenderCorrectApplicationDetails()
    {
      var sut=new Views.LoanApplication.Accepted();

      var model = new LoanApplication
      {
        ID = 99,
        FirstName = "Gentry",
        LastName = "Smith",
        Age = 33,
        AnnualIncome = 12345.67m
      };

      var html = sut.RenderAsHtml(model);

      var renderedFirstName = html.GetElementbyId("firstName").InnerText;

      // not possible to test partial view.
       Assert.That(renderedFirstName, Is.EqualTo("Gentry"));
    }
  }
}