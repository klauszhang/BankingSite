using BankingSite.Models;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BankingSite.UnitTests
{
  [TestFixture]
  public class LoanApplicationScorerTest
  {
    [Test]
    public void ShouldDeclineWhenNotTooyoungAndWEalthyButPoorCredit_Classical()
    {
      var sut = new LoanApplicationScorer(new CreditHistoryChecker());

      var application = new LoanApplication
      {
        FirstName = "Sarah",
        LastName = "Smith",

        AnnualIncome = 10000000.01m,
        Age = 22
      };

      sut.ScoreApplication(application);

      Assert.That(application.IsAccepted, Is.False);
    }

    [Test]
    public void ShouldDeclineWhenNotTooyoungAndWEalthyButPoorCredit()
    {
      var fakeCreditHistoryChecker = new Mock<ICreditHistoryChecker>();
      fakeCreditHistoryChecker
        .Setup(x => x.CheckCreditHistory(It.IsAny<string>(), It.IsAny<string>()))
        .Returns(false);

      var sut = new LoanApplicationScorer(fakeCreditHistoryChecker.Object);

      var application = new LoanApplication
      {
        AnnualIncome = 10000000.01m,
        Age = 22
      };

      sut.ScoreApplication(application);

      Assert.That(application.IsAccepted, Is.False);
    }
  }
}
