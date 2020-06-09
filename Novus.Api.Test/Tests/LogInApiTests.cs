using System;
using FluentAssertions;
using Novus.Api.Test.Clients;
using Novus.Api.Test.Models.Users;
using NUnit.Framework;
using Novus.Api.Test.Helpers;

namespace Novus.Api.Test
{
    public class LogInApiTests
    {
        [Test]
        public void LogInWithCorrectData()
        {
            var loginModel = new RequestLogInModel
            {
                Login = TestData.Phone, 
                Password = TestData.Passwords
            };

            var responseLogInModel = new NovusApiClient().LogInRequest(loginModel);

            responseLogInModel.UserId.Should().Be(TestData.UserId);
        }
        
        [Test]
        public void LogInWithWrongPassword()
        {
            var loginModel = new RequestLogInModel
            {
                Login = TestData.Phone, 
                Password = "840304"
            };

            var responseLogInModel = new NovusApiClient().LogInWithWrongDataRequest(loginModel);

            responseLogInModel.Errors[0].ErrorCode.Should().Be(ErrorCode.LoginDataIncorrect);
            responseLogInModel.Errors[0].Description.Should().Be(ErrorMessages.LoginDataIncorrect);
        }
        
        [Test]
        public void LogInWithWrongPhone()
        {
            var loginModel = new RequestLogInModel
            {
                Login = "380936536900", 
                Password = TestData.Passwords
            };

            var responseLogInModel = new NovusApiClient().LogInWithWrongDataRequest(loginModel);

            responseLogInModel.Errors[0].ErrorCode.Should().Be(ErrorCode.LoginDataIncorrect);
            responseLogInModel.Errors[0].Description.Should().Be(ErrorMessages.LoginDataIncorrect);
        }
        
        [Test]
        public void LogInWithInvalidPhoneParameter()
        {
            var loginModel = new RequestLogInModel
            {
                Login = "0936535906", 
                Password = TestData.Passwords
            };

            var responseLogInModel = new NovusApiClient().LogInWithWrongDataRequest(loginModel);

            responseLogInModel.Errors[0].ErrorCode.Should().Be(ErrorCode.PhoneDataInvalid);
            responseLogInModel.Errors[0].Description.Should().Be(ErrorMessages.PhoneDataInvalid);
        }
        
        [Test]
        public void LogInWithoutPhoneParameter()
        {
            var loginModel = new RequestLogInModel
            {
                Login = "", 
                Password = TestData.Passwords
            };

            var responseLogInModel = new NovusApiClient().LogInWithWrongDataRequest(loginModel);

            responseLogInModel.Errors[0].ErrorCode.Should().Be(ErrorCode.InvalidLogInParameterFormat);
            responseLogInModel.Errors[0].Description.Should().Be(ErrorMessages.InvalidPhoneParameterFormat);
        }
        
        [Test]
        public void LogInWithoutPasswordParameter()
        {
            var loginModel = new RequestLogInModel
            {
                Login = TestData.Phone, 
                Password = ""
            };

            var responseLogInModel = new NovusApiClient().LogInWithWrongDataRequest(loginModel);

            responseLogInModel.Errors[0].ErrorCode.Should().Be(ErrorCode.InvalidLogInParameterFormat);
            responseLogInModel.Errors[0].Description.Should().Be(ErrorMessages.InvalidPasswordParameterFormat);
        }
        
        [Test]
        public void LogInWithoutLogInParameters()
        {
            var loginModel = new RequestLogInModel
            {
                Login = "", 
                Password = ""
            };

            var responseLogInModel = new NovusApiClient().LogInWithWrongDataRequest(loginModel);

            responseLogInModel.Errors[0].ErrorCode.Should().Be(ErrorCode.InvalidLogInParameterFormat);
            responseLogInModel.Errors[0].Description.Should().Be(ErrorMessages.InvalidPhoneParameterFormat);
        }
    }
}