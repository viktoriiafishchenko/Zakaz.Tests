using System.Collections.Generic;
using Newtonsoft.Json;
namespace Novus.Api.Test.Models.Users
{
    public class RequestChangeUserInfoModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("birthdate")]
        public string Birthdate { get; set; }
       
        [JsonProperty("emails")]

        public List<string> Emails { get; set; }
        
        [JsonProperty("subscribed_to_marketing")]
        public bool SubscribedToMarketing { get; set; }
        
    }
}