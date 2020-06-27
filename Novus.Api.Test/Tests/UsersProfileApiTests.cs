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
            var requestChangeUserEmailModel = new RequestChangeUserInfoModel
            {
                Name = TestData.Name,
                Birthdate = "",
                SubscribedToMarketing = false,
                Emails = new List<string>
                {
                    "test@gmail.com"
                }
            };
            _client.ChangeUserDataRequest(requestChangeUserEmailModel);
        }

        [Test]
        public void CheckUserInfo()
        {
            var responseUserInfoModel = _client.UserInfoRequest();
            
            responseUserInfoModel.Emails.Should().ContainSingle();
            responseUserInfoModel.Emails[0].Email.Should().Be(TestData.Email);
            responseUserInfoModel.Emails[0].IsEditable.Should().Be(true);
            responseUserInfoModel.HasDeliveryPresets.Should().Be(false);
            responseUserInfoModel.IsHoreca.Should().Be(false);
            responseUserInfoModel.LastVisit.Should().Be(TestData.Novus);
            responseUserInfoModel.Login.Phone.Should().Be(TestData.Phone);
            responseUserInfoModel.Name.Should().Be(TestData.Name);
            responseUserInfoModel.Phones.Should().ContainSingle();
            responseUserInfoModel.Phones[0].Phone.Should().Be(TestData.Phone);
            responseUserInfoModel.Phones[0].IsEditable.Should().Be(false);
            responseUserInfoModel.Registered.Should().Be(true);
            responseUserInfoModel.SubscribedToMarketing.Should().Be(false);
        }

        [Test]
        public void ChangeUserEmail()
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
            _client.ChangeUserDataRequest(requestChangeUserEmailModel);
            var responseUserInfoModel = _client.UserInfoRequest();

            responseUserInfoModel.Emails[0].Email.Should().Be("test1@gmail.com");
            responseUserInfoModel.Emails[0].IsEditable.Should().Be(true);
            responseUserInfoModel.Phones[0].Phone.Should().Be(TestData.Phone);
            responseUserInfoModel.Phones[0].IsEditable.Should().Be(false);
            responseUserInfoModel.Name.Should().Be(TestData.Name);
            responseUserInfoModel.Birthdate.Should().Be(TestData.Birthdate);
            responseUserInfoModel.LastVisit.Should().Be(TestData.Novus);
            responseUserInfoModel.Registered.Should().Be(true);
            responseUserInfoModel.SubscribedToMarketing.Should().Be(false);
            responseUserInfoModel.HasDeliveryPresets.Should().Be(false);
            responseUserInfoModel.IsHoreca.Should().Be(false);
        }

        [Test]
        public void ChangeUserName()
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
            _client.ChangeUserDataRequest(requestChangeUserNameModel);
            var responseUserInfoModel = _client.UserInfoRequest();

            responseUserInfoModel.Emails[0].Email.Should().Be(TestData.Email);
            responseUserInfoModel.Emails[0].IsEditable.Should().Be(true);
            responseUserInfoModel.Phones[0].Phone.Should().Be(TestData.Phone);
            responseUserInfoModel.Phones[0].IsEditable.Should().Be(false);
            responseUserInfoModel.Name.Should().Be("Test");
            responseUserInfoModel.Birthdate.Should().Be(TestData.Birthdate);
            responseUserInfoModel.LastVisit.Should().Be(TestData.Novus);
            responseUserInfoModel.Registered.Should().Be(true);
            responseUserInfoModel.SubscribedToMarketing.Should().Be(false);
            responseUserInfoModel.HasDeliveryPresets.Should().Be(false);
            responseUserInfoModel.IsHoreca.Should().Be(false);
        }

        [Test]
        public void ChangeUserBirthday()
        {
            var requestChangeBirthdayNameModel = new RequestChangeUserInfoModel
            {
                Name = TestData.Name,
                Birthdate = "2011-11-11",
                SubscribedToMarketing = false,
                Emails = new List<string>
                {
                    TestData.Email
                }
            };
            _client.ChangeUserDataRequest(requestChangeBirthdayNameModel);
            var responseUserInfoModel = _client.UserInfoRequest();

            responseUserInfoModel.Emails[0].Email.Should().Be(TestData.Email);
            responseUserInfoModel.Emails[0].IsEditable.Should().Be(true);
            responseUserInfoModel.Phones[0].Phone.Should().Be(TestData.Phone);
            responseUserInfoModel.Phones[0].IsEditable.Should().Be(false);
            responseUserInfoModel.Name.Should().Be(TestData.Name);
            responseUserInfoModel.Birthdate.Should().Be("2011-11-11");
            responseUserInfoModel.LastVisit.Should().Be(TestData.Novus);
            responseUserInfoModel.Registered.Should().Be(true);
            responseUserInfoModel.SubscribedToMarketing.Should().Be(false);
            responseUserInfoModel.HasDeliveryPresets.Should().Be(false);
            responseUserInfoModel.IsHoreca.Should().Be(false);
        }

        [Test]
        public void ChangeSubscribedToMarketing()
        {
            var requestChangeSubscribedToMarketingModel = new RequestChangeUserInfoModel
            {
                Name = TestData.Name,
                Birthdate = TestData.Birthdate,
                SubscribedToMarketing = true,
                Emails = new List<string>
                {
                    TestData.Email
                }
            };
            _client.ChangeUserDataRequest(requestChangeSubscribedToMarketingModel);
            var responseUserInfoModel = _client.UserInfoRequest();

            responseUserInfoModel.Emails[0].Email.Should().Be(TestData.Email);
            responseUserInfoModel.Emails[0].IsEditable.Should().Be(true);
            responseUserInfoModel.Phones[0].Phone.Should().Be(TestData.Phone);
            responseUserInfoModel.Phones[0].IsEditable.Should().Be(false);
            responseUserInfoModel.Name.Should().Be(TestData.Name);
            responseUserInfoModel.Birthdate.Should().Be(TestData.Birthdate);
            responseUserInfoModel.LastVisit.Should().Be(TestData.Novus);
            responseUserInfoModel.Registered.Should().Be(true);
            responseUserInfoModel.SubscribedToMarketing.Should().Be(true);
            responseUserInfoModel.HasDeliveryPresets.Should().Be(false);
            responseUserInfoModel.IsHoreca.Should().Be(false);
        }

        [TestCase("test@")]
        [TestCase("@test.com")]
        [TestCase("test@test")]
        [TestCase("@gmail.com")]
        [TestCase("test@@test.com")]

        public void UpdateUserEmailWithIncorrectData(string email)
        {
            var requestChangeEmailModel = new RequestChangeUserInfoModel
            {
                Name = TestData.Name,
                Birthdate = TestData.Birthdate,
                SubscribedToMarketing = false,
                Emails = new List<string>
                {
                    email
                }
            };
            var responseUserInfoModel = _client.ReplacementUserInfoWithIncorrectParametersRequest(requestChangeEmailModel);
            responseUserInfoModel.Errors[0].ErrorCode.Should().Be(ErrorCode.InvalidEmailParameterFormat);
            responseUserInfoModel.Errors[0].Description.Should().Be(ErrorMessages.InvalidEmailParameterFormat);
        }

        [TestCase("1111-11-11")]
        [TestCase("2022-01-01")]
        [TestCase("2020-01-01")]
        [TestCase("2000.03.12")]
        [TestCase("16-06-2006")]
        [TestCase("1976-10-o6")]
        [TestCase("2019-02-29")]
        [TestCase("2011-02-233")]
        public void UpdateUserBirthdateWithIncorrectData(string birthdate)
        {
            var requestChangeBirthdateModel = new RequestChangeUserInfoModel
            {
                Name = TestData.Name,
                Birthdate = birthdate,
                SubscribedToMarketing = false,
                Emails = new List<string>
                {
                    TestData.Email
                }
            };
            var responseUserInfoModel = _client.ReplacementUserInfoWithIncorrectParametersRequest(requestChangeBirthdateModel);
            responseUserInfoModel.Errors[0].ErrorCode.Should().Be(ErrorCode.InvalidBirthdateParameterFormat);
            responseUserInfoModel.Errors[0].Description.Should().Be(ErrorMessages.InvalidBirthdateParameterFormat);
        }

        [Test]
        public void LogOutFromProfile()
        {
            _client.LogOutFromProfileRequest();
            
            var responseUserInfoModel = _client.GetInfoWithoutUnauthorizedRequest();
            responseUserInfoModel.Errors[0].ErrorCode.Should().Be(ErrorCode.Unauthorized);
            responseUserInfoModel.Errors[0].Description.Should().Be(ErrorMessages.BadRequest);
        }
    }
}