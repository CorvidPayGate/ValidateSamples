namespace PayGate.Validate.Examples
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using IdentityModel.Client;

    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// The TokenFactory interface.
    /// </summary>
    public interface ITokenFactory
    {
        Task<string> GetAccessToken();
    }

    /// <summary>
    /// The token factory.
    /// </summary>
    public class TokenFactory : ITokenFactory
    {
        /// <summary>
        /// The _access token.
        /// </summary>
        private string _accessToken = string.Empty;

        /// <summary>
        /// The _expire time.
        /// </summary>
        private DateTime _expireTime;

        /// <summary>
        /// The _configuration.
        /// </summary>
        private IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenFactory"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public TokenFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// The get access token.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<string> GetAccessToken()
        {
            if (!string.IsNullOrEmpty(_accessToken) && _expireTime >= DateTime.Now)
            {
                return _accessToken;
            }

            using (HttpClient client = new HttpClient())
            {
                TokenResponse response = await client.RequestClientCredentialsTokenAsync(
                                             new ClientCredentialsTokenRequest()
                                                 {
                                                     Address = _configuration.GetValue<string>("TokenEndpoint"),
                                                     ClientId = "validate_api",
                                                     ClientSecret = _configuration.GetValue<string>("Secret"),
                                                     Scope = "API"
                                                 });

                _accessToken = response.AccessToken;
                _expireTime = DateTime.Now.AddSeconds(response.ExpiresIn);
            }

            return _accessToken;
        }
    }
}
