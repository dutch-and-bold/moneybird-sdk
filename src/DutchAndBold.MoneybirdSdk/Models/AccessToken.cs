using System.Text.Json.Serialization;

namespace DutchAndBold.MoneybirdSdk.Models
{
    public class AccessToken
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        [JsonPropertyName("access_token")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the token type. Moneybird defaults to 'bearer'.
        /// </summary>
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets refresh token.
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the token scope.
        /// </summary>
        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the expires in (milliseconds).
        /// </summary>
        [JsonPropertyName("expires_in")]
        public double ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the Moneybird created at unix timestamp.
        /// </summary>
        [JsonPropertyName("created_at")]
        public double CreatedAt { get; set; }

        /// <summary>
        /// Gets truth check if the token has been expired.
        /// Currently this value is always false for the Moneybird tokens.
        /// </summary>
        [JsonIgnore]
        public bool IsExpired { get; } = false;
    }
}