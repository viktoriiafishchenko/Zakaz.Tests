using Newtonsoft.Json;
using System.Collections.Generic;

namespace Novus.Api.Test.Models.Users
{
    public class ResponseErrorsModel
    {
        [JsonProperty("errors")]
        public List<ErrorData> Errors { get; set; }
        
        public class ErrorData
        {
            [JsonProperty("error_code")]
            public int ErrorCode { get; set; }
            [JsonProperty("description")]
            public string Description { get; set; }
        }
    }
}