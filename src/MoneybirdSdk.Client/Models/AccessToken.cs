namespace MoneybirdSdk.Client.Models
{
    public class AccessToken
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        public string Value { get; set; }

        
        /// <summary>
        /// Gets or sets the token type. Moneybird defaults to 'bearer'.
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets refresh token.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the token scope.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the expires in (milliseconds).
        /// </summary>
        public double ExpiresIn { get; set; }
        
        /// <summary>
        /// Gets or sets the Moneybird created at unix timestamp.
        /// </summary>
        public double CreatedAt { get; set; }

        /// <summary>
        /// Gets truth check if the token has been expired.
        /// Currently this value is always false for the Moneybird tokens.
        /// </summary>
        public bool IsExpired { get; } = false;
    }
}