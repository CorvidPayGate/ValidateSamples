

namespace PayGate.Validate.Examples.Controllers
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    using Newtonsoft.Json;

    /// <summary>
    /// The example controller.
    /// </summary>
    [Route("api/[controller]")]
    public class ExampleController : Controller
    {
        /// <summary>
        /// The _key code.
        /// </summary>
        private readonly string _keyCode = string.Empty;

        /// <summary>
        /// The _base api url.
        /// </summary>
        private readonly string _baseApiUrl = string.Empty;

        /// <summary>
        /// The _token factory.
        /// </summary>
        private readonly ITokenFactory _tokenFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleController"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <param name="tokenFactory">
        /// The token factory.
        /// </param>
        public ExampleController(IConfiguration configuration, ITokenFactory tokenFactory)
        {
            _tokenFactory = tokenFactory;
            _keyCode = configuration.GetValue<string>("Keycode");
            _baseApiUrl = configuration.GetValue<string>("BaseApiUrl");
        }

        /// <summary>
        /// The get account number.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("AccountNumber")]
        public async Task<IActionResult> GetAccountNumber()
        {
            try
            {
                using (HttpClient client = new HttpClient() { BaseAddress = new Uri(_baseApiUrl) })
                {
                    client.SetBearerToken(await _tokenFactory.GetAccessToken());
                    var data = new { SortCode = "010101", KeyCode = _keyCode };
                    var response = await client.PostAsync(
                                       "api/AccountNumber",
                                       new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));

                    return Json(await response.Content.ReadAsAsync<object>());
                }
            }
            catch (Exception)
            { 
                return StatusCode(500);
            }
        }

        [HttpGet("CreditCard")]
        public async Task<IActionResult> GetCreditCard()
        {
            try
            {
                using (HttpClient client = new HttpClient() { BaseAddress = new Uri(_baseApiUrl) })
                {
                    client.SetBearerToken(await _tokenFactory.GetAccessToken());
                    var data = new { CreditCardNumber = "4111111111111111", KeyCode = _keyCode };
                    var response = await client.PostAsync(
                                       "api/CreditCard",
                                       new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));

                    return Json(await response.Content.ReadAsAsync<object>());
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("Iban")]
        public async Task<IActionResult> GetIban()
        {
            try
            {
                using (HttpClient client = new HttpClient() { BaseAddress = new Uri(_baseApiUrl) })
                {
                    client.SetBearerToken(await _tokenFactory.GetAccessToken());
                    var data = new { Iban = "GB32ESSE40486562136016", KeyCode = _keyCode };
                    var response = await client.PostAsync(
                                       "api/Iban",
                                       new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));

                    return Json(await response.Content.ReadAsAsync<object>());
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}