using Newtonsoft.Json;

namespace Novus.Api.Test.Models.Users
{
    public class RequestLogInModel
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}