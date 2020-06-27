using System.Collections.Generic;
using FluentAssertions;
using Novus.Api.Test.Clients;
using Novus.Api.Test.Models.Users;
using NUnit.Framework;
using Novus.Api.Test.Helpers;
namespace Novus.Api.Test
{
    public class UserProfileWithoutAuthorizeTests
    {
        private NovusApiClient _client = new NovusApiClient();
        
        [Test]
        public void CheckUserInfoWithoutAuthorize()
        {
            var responseUserInfoModel = _client.GetInfoWithoutUnauthorizedRequest();
            responseUserInfoModel.Errors[0].ErrorCode.Should().Be(ErrorCode.Unauthorized);
            responseUserInfoModel.Errors[0].Description.Should().Be(ErrorMessages.BadRequest);
        }

        [Test]
        public void ChangeUserEmailWithoutAuthorize()
        {
            var requestChangeUserEmailModel = new RequestChangeUserInfoModel
            {
                Name = TestData.Name,
                Birthdate = "",
                SubscribedToMarketing = false,
                Emails = new List<string>
                {
                    "test1@gmail.com"
                }
            };
            _client.ChangeUserDataWithoutUnauthorizedRequest(requestChangeUserEmailModel);

            var responseUserInfoModel = _client.GetInfoWithoutUnauthorizedRequest();
            responseUserInfoModel.Errors[0].ErrorCode.Should().Be(ErrorCode.Unauthorized);
            responseUserInfoModel.Errors[0].Description.Should().Be(ErrorMessages.BadRequest);

        }

        [Test]
        public void ChangeUserNameWithoutAuthorize()
        {
            var requestChangeUserNameModel = new RequestChangeUserInfoModel
            {
                Name = "Test",
                Birthdate = "",
                SubscribedToMarketing = false,
                Emails = new List<string>
                {
                    TestData.Email
                }
            };
            _client.ChangeUserDataWithoutUnauthorizedRequest(requestChangeUserNameModel);
            var responseUserInfoModel = _client.GetInfoWithoutUnauthorizedRequest();
            responseUserInfoModel.Errors[0].ErrorCode.Should().Be(ErrorCode.Unauthorized);
            responseUserInfoModel.Errors[0].Description.Should().Be(ErrorMessages.BadRequest);
        }

        [Test]
        public void ChangeUserBirthdayWithoutAuthorize()
        {
            var requestChangeUserBirthdayModel = new RequestChangeUserInfoModel
            {
                Name = TestData.Name,
                Birthdate = "12.12.2012",
                SubscribedToMarketing = false,
                Emails = new List<string>
                {
                    TestData.Email
                }
            };
            _client.ChangeUserDataWithoutUnauthorizedRequest(requestChangeUserBirthdayModel);
            var responseUserInfoModel = _client.GetInfoWithoutUnauthorizedRequest();
            responseUserInfoModel.Errors[0].ErrorCode.Should().Be(ErrorCode.Unauthorized);
            responseUserInfoModel.Errors[0].Description.Should().Be(ErrorMessages.BadRequest);
        }

        [Test]
        public void ChangeUserSubscribedToMarketingWithoutAuthorize()
        {
            var requestChangeUserSubscribedToMarketingModel = new RequestChangeUserInfoModel
            {
                Name = TestData.Name,
                Birthdate = "",
                SubscribedToMarketing = true,
                Emails = new List<string>
                {
                    TestData.Email
                }
            };
            _client.ChangeUserDataWithoutUnauthorizedRequest(requestChangeUserSubscribedToMarketingModel);
            var responseUserInfoModel = _client.GetInfoWithoutUnauthorizedRequest();
            responseUserInfoModel.Errors[0].ErrorCode.Should().Be(ErrorCode.Unauthorized);
            responseUserInfoModel.Errors[0].Description.Should().Be(ErrorMessages.BadRequest);
        }
    }
}