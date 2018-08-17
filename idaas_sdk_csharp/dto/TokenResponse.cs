using Newtonsoft.Json;
using System;

/**
 * @author Miguel Pazo (http://miguelpazo.com)
 */
namespace idaas_sdk_csharp.dto
{
    public class TokenResponse
    {
        [JsonProperty("token_type")]
        public String tokenType { get; set; }
        [JsonProperty("access_token")]
        public String accessToken { get; set; }
        [JsonProperty("expires_in")]
        public Int32 expiresIn { get; set; }
        [JsonProperty("id_token")]
        public String idToken { get; set; }
        [JsonProperty("refresh_token")]
        public String refreshToken { get; set; }
        public IdToken idTokenObject { get; set; }
    }
}
