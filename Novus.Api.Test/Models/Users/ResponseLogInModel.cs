using Newtonsoft.Json;

namespace Novus.Api.Test.Models.Users
{
    public class ResponseLogInModel
    {
        
        [JsonProperty("expires")]
        public long Expires { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}