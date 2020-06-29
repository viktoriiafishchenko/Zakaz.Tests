using System.Linq;
using FluentAssertions;
using Novus.Api.Test.Clients;
using Novus.Api.Test.Models.Users;
using NUnit.Framework;
using Novus.Api.Test.Helpers;

namespace Novus.Api.Test
{
    public class ProductsTests
    {
        private NovusApiClient _client = new NovusApiClient();

        [SetUp]
        public void Init()
        {
            var loginModel = new RequestLogInModel
            {
                Login = TestData.Phone,
                Password = TestData.Passwords
            };
            _client.LogInRequest(loginModel);
        }

        [Test]
        public void SearchProdueserTest()
        {
            _client.ApplyLanguage(Languages.Ukrainian);
            const string ProduserName = "Norven";
            var responseSearchProductModel = _client.SearchProductResponse(ProduserName);
            responseSearchProductModel.Results.Any(r => r.Title.ToLower().Contains(ProduserName.ToLower())).Should().BeTrue("Title should contain search term");
            responseSearchProductModel.Results.Any(r => r.Currency.Contains("uah")).Should().BeTrue("Currency should contain uah");
            responseSearchProductModel.Results.Any(r => r.Producer.Trademark.Contains(ProduserName.ToUpper())).Should().BeTrue("Producer should contain search term");
            responseSearchProductModel.Results.Any(r => r.Price > 0).Should().BeTrue("Price should be > 0");
            responseSearchProductModel.Results.Any(r => r.Weight > 0).Should().BeTrue("Weight should be > 0");
            responseSearchProductModel.Count.Should().BePositive("Product count should be > 0");
        }
        
        [Test]
        public void SearchNonExistentProduct()
        {
            var responseSearchProductModel = _client.SearchProductResponse("454knb");
            responseSearchProductModel.Results.Should().BeEmpty();
        }

        [Test]
        public void SearchProductTest()
        {
            const string ProductName = "Хліб";
            _client.ApplyLanguage(Languages.Ukrainian);
            var responseSearchProductModel = _client.SearchProductResponse(ProductName);
            responseSearchProductModel.Results.Any(r => r.Title.ToLower().Contains(ProductName.ToLower())).Should().BeTrue($"Title should contain search term {ProductName}");
            responseSearchProductModel.Results.Any(r => r.Currency.Contains("uah")).Should().BeTrue("Currency should contain uah");
            responseSearchProductModel.Results.Any(r => r.Price > 0).Should().BeTrue("Price should be > 0");
            responseSearchProductModel.Results.Any(r => r.Weight > 0).Should().BeTrue("Weight should be > 0");
            responseSearchProductModel.Count.Should().BePositive("Product count should be > 0");
        }
    }
}