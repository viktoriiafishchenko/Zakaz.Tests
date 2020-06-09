using System.Collections.Generic;
using Newtonsoft.Json;

namespace Novus.Api.Test.Models.Users
{
    public class ResponseUserInfoModel
    {
        [JsonProperty("emails")]
        public List<EmailData> Emails { get; set; }
        
        [JsonProperty("has_delivery_presets")]
        public bool HasDeliveryPresets { get; set; }
        
        [JsonProperty("is_horeca")]
        public bool IsHoreca { get; set; }
        
        [JsonProperty("birthday")]
        public string Birthday { get; set; }
        
        [JsonProperty("last_visit")]
        public string LastVisit { get; set; }
        
        [JsonProperty("login")]
        public LoginData Login { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("phones")]
        public List<PhonesData> Phones { get; set; }
        
        [JsonProperty("registered")]
        public bool Registered { get; set; }
        
        [JsonProperty("subscribed_to_marketing")]
        public bool SubscribedToMarketing { get; set; }
    }

    public class EmailData
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("is_editable")]
        public bool IsEditable { get; set; }
    }
    public class LoginData 
    {
        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
    public class PhonesData
    {
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("is_editable")]
        public bool IsEditable { get; set; }
    }
}