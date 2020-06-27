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
        public void SearchProductsTest()
        {
            var responseUserInfoModel = _client.SearchProductResponse("Norven");
            responseUserInfoModel.Results.Any(r => r.Title.Contains("Norven")).Should().BeTrue();
        }
    }
}