using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using Novus.Api.Test.Helpers;
using Novus.Api.Test.Models.Users;

namespace Novus.Api.Test.Clients
{
    public class NovusApiClient
    {
        private HttpClient _httpClient;

        public NovusApiClient(params Cookie[] cookies)
        {
            var cookieContainer = new CookieContainer();
            cookies?.ToList().ForEach(cookie => cookieContainer.Add(cookie));
            var httpClientHandler = new HttpClientHandler {CookieContainer = cookieContainer};

            _httpClient = new HttpClient(httpClientHandler)
            {
                BaseAddress = new Uri(TestData.BaseUrl),
                DefaultRequestHeaders =
                {
                    {"Accept", "application/json"},
                    {"User-Agent", "x"},
                    {"x-chain", "novus"}
                }
            };
        }

        public ResponseLogInModel LogInRequest(RequestLogInModel model)
        {
            var message = _httpClient.PostAsJsonAsync(EndpointsHelper.UserLogIn, model).Result;
            message.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseModel = message.Content.ReadAsAsync<ResponseLogInModel>().Result;

            return responseModel;
        }
        public ResponseErrorsModel LogInWithWrongDataRequest(RequestLogInModel model)
        {
            var message = _httpClient.PostAsJsonAsync(EndpointsHelper.UserLogIn, model).Result;
            message.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseModel = message.Content.ReadAsAsync<ResponseErrorsModel>().Result;
            return responseModel;
        }

        public ResponseUserInfoModel UserInfoRequest()
        {
            var message = _httpClient.GetAsync(EndpointsHelper.UserInfo).Result;
            message.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseModel = message.Content.ReadAsAsync<ResponseUserInfoModel>().Result;

            return responseModel;
        }
        public ResponseErrorsModel GetInfoWithoutUnauthorizedRequest()
        {
            var message = _httpClient.GetAsync(EndpointsHelper.UserInfo).Result;
            message.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            var responseModel = message.Content.ReadAsAsync<ResponseErrorsModel>().Result;
            return responseModel;
        }
        public void ChangeUserDataRequest(RequestChangeUserInfoModel model)
        {
            var message = _httpClient.PostAsJsonAsync(EndpointsHelper.UserPersonalInfo, model).Result;
            message.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}