using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSite.Models;
using NUnit.Framework;

namespace BankingSite.IntegrationTests
{
  [TestFixture]
  public class RepositoryTests
  {
    [Test]
    public void ShouldPopulateIdOnCreateLoanApplication()
    {
      var sut = new Repository();
      var applicationToSave = new LoanApplication
      {
        FirstName = "Gentry",
        LastName = "Smith",
        Age = 33,
        AnnualIncome = 123456.66m
      };

      sut.Create(applicationToSave);

      Assert.That(applicationToSave.ID, Is.Not.EqualTo(0));
    }
  }
}
