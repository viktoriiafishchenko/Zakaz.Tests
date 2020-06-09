using System.Collections.Generic;
using FluentAssertions;
using Novus.Api.Test.Clients;
using Novus.Api.Test.Models.Users;
using NUnit.Framework;
using Novus.Api.Test.Helpers;

namespace Novus.Api.Test
{
    public class UsersProfileApiTests
    {
        [Test]
        public void CheckUserInfo()
        {
            var loginModel = new RequestLogInModel
            {
                Login = TestData.Phone, 
                Password = TestData.Passwords
            };
            var apiClient = new NovusApiClient();
            apiClient.LogInRequest(loginModel);
            var responseUserInfoModel = apiClient.UserInfoRequest();
            
            responseUserInfoModel.Emails.Should().ContainSingle();
            responseUserInfoModel.Emails[0].Email.Should().Be(TestData.Email);
            responseUserInfoModel.Emails[0].IsEditable.Should().Be(true);
            responseUserInfoModel.HasDeliveryPresets.Should().Be(true);
            responseUserInfoModel.IsHoreca.Should().Be(false);
            responseUserInfoModel.LastVisit.Should().Be(TestData.Novus);
            responseUserInfoModel.Login.Phone.Should().Be(TestData.Phone);
            responseUserInfoModel.Name.Should().Be(TestData.Name);
            responseUserInfoModel.Phones.Should().ContainSingle();
            responseUserInfoModel.Phones[0].Phone.Should().Be(TestData.Phone);
            responseUserInfoModel.Phones[0].IsEditable.Should().Be(false);
            responseUserInfoModel.Registered.Should().Be(true);
            responseUserInfoModel.SubscribedToMarketing.Should().Be(true);
        }
        
        [Test]
        public void CheckUserInfoWithoutLogin()
        {
            var apiClient = new NovusApiClient();
            var responseUserInfoModel = apiClient.GetInfoWithoutUnauthorizedRequest();
            responseUserInfoModel.Errors[0].ErrorCode.Should().Be(ErrorCode.Unauthorized);
            responseUserInfoModel.Errors[0].Description.Should().Be(ErrorMessages.BadRequest);
        }

        [Test]
        public void ChangeUserEmail()
        {
            var loginModel = new RequestLogInModel
            {
                Login = TestData.Phone, 
                Password = TestData.Passwords
            };
            var apiClient = new NovusApiClient();
            apiClient.LogInRequest(loginModel);
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
            apiClient.ChangeUserDataRequest(requestChangeUserEmailModel);
            var responseUserInfoModel = apiClient.UserInfoRequest();

            responseUserInfoModel.Emails[0].Email.Should().Be("test1@gmail.com");
            responseUserInfoModel.Emails[0].IsEditable.Should().Be(true);
            responseUserInfoModel.Phones[0].Phone.Should().Be(TestData.Phone);
            responseUserInfoModel.Phones[0].IsEditable.Should().Be(false);
            responseUserInfoModel.Name.Should().Be(TestData.Name);
            responseUserInfoModel.Birthday.Should().Be(TestData.Birthday);
            responseUserInfoModel.LastVisit.Should().Be(TestData.Novus);
            responseUserInfoModel.Registered.Should().Be(true);
            responseUserInfoModel.SubscribedToMarketing.Should().Be(false);
            responseUserInfoModel.HasDeliveryPresets.Should().Be(false);
            responseUserInfoModel.IsHoreca.Should().Be(false);
        }
    }
}