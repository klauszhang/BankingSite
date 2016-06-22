using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BankingSite.Controllers;
using BankingSite.Models;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace BankingSite.ControllerTest
{
  [TestFixture]
  public class LoanApplicationControllerTests
  {
    [Test]
    public void ShouldRenderDefaultView()
    {
      var fakerepository = new Mock<IRepository>();
      var fakeLoanApplicationScorer = new Mock<ILoanApplicationScorer>();

      var sut = new LoanApplicationController(fakerepository.Object, fakeLoanApplicationScorer.Object);

      sut.WithCallTo(x => x.Apply()).ShouldRenderDefaultView();
    }

    [Test]
    public void ShouldRedirectToAcceptedViewOnSuccessfulApplication()
    {
      var fakerepository = new Mock<IRepository>();
      var fakeLoanApplicationScorer = new Mock<ILoanApplicationScorer>();

      var sut = new LoanApplicationController(fakerepository.Object, fakeLoanApplicationScorer.Object);

      var acceptApplication = new LoanApplication
      {
        IsAccepted = true,
      };

      sut.WithCallTo(x => x.Apply(acceptApplication))
        .ShouldRedirectTo<int>(x => x.Accepted);
    }

    [Test]
    public void ShouldRedirectToDeclineViewOnUnsuccessfulApplication()
    {
      var fakerepository = new Mock<IRepository>();
      var fakeLoanApplicationScorer = new Mock<ILoanApplicationScorer>();

      var sut = new LoanApplicationController(fakerepository.Object, fakeLoanApplicationScorer.Object);

      var acceptApplication = new LoanApplication
      {
        IsAccepted = false,
      };

      sut.WithCallTo(x => x.Apply(acceptApplication))
        .ShouldRedirectTo<int>(x => x.Declined);
    }
  }
}
