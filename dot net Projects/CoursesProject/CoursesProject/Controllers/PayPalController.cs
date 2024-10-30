using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CoursesProject.Controllers
{
    [IgnoreAntiforgeryToken]
    public class PayPalController : Controller
    {
        public string PaypalClientId { get; set; } = "";
        private string PayPalSecret { get; set; } = "";
        public string PayPalUrl { get; set; } = "";

        public PayPalController(IConfiguration configuration)
        {
            PaypalClientId = configuration["PayPalSettings:ClientId"]!;
            PayPalSecret = configuration["PayPalSettings:Secret"]!;
            PayPalUrl = configuration["PayPalSettings:Url"]!;
        }
        [HttpPost]
        public JsonResult CreateOrder([FromBody] decimal amount)
        {
            string accessToken = GetPaypalAccessToken();
            string orderId = "";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var requestBody = new
                {
                    intent = "CAPTURE",
                    purchase_units = new[]
                    {
                    new {
                        amount = new {
                            currency_code = "USD",
                            value = amount.ToString("F2")  // Example amount
                        }
                    }
                },
                    //application_context = new
                    //{
                    //    return_url = "https://localhost:7115/paypal/complete",
                    //    cancel_url = "https://localhost:7115/paypal/cancel"
                    //}
                };

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, PayPalUrl + "/v2/checkout/orders");
                requestMessage.Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

                var responseTask = client.SendAsync(requestMessage);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var jsonResponse = JsonNode.Parse(readTask.Result);
                    orderId = jsonResponse?["id"]?.ToString() ?? "";
                }
            }

            return new JsonResult(new { Id=orderId });
        }
        [HttpPost]
        public JsonResult CompleteOrder([FromBody] string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
                return new JsonResult("");

            string accessToken = GetPaypalAccessToken();
            string captureUrl = PayPalUrl + $"/v2/checkout/orders/{orderId}/capture";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, captureUrl);
                requestMessage.Content = new StringContent("{}", Encoding.UTF8, "application/json");

                var responseTask = client.SendAsync(requestMessage);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var jsonResponse = JsonNode.Parse(readTask.Result);
                    if (jsonResponse != null)
                    {
                        string PaypalOrderStatus = jsonResponse["status"]?.ToString() ?? "";
                        if (PaypalOrderStatus == "COMPLETED")
                        {

                            return new JsonResult("success");
                        }
                    }
       
                }
                else
                {
                    var responseContent = result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"Token validation failed: {result.StatusCode}, {responseContent}");
                }
            }

            return new JsonResult("");
        }

        //[HttpPost]
        //public JsonResult CancelOrder([FromBody] string orderId)
        //{
        //    if (string.IsNullOrEmpty(orderId))
        //        return new JsonResult("");

        //    return new JsonResult("");
        //}
        private string GetPaypalAccessToken()
        {
            string accessToken = "";
            string url = PayPalUrl + "/v1/oauth2/token";

            using (var client = new HttpClient())
            {
                string credentials64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(PaypalClientId + ":" + PayPalSecret));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + credentials64);

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

                var requestTask = client.SendAsync(requestMessage);
                requestTask.Wait();

                var result = requestTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var jsonResponse = JsonNode.Parse(readTask.Result);
                    if (jsonResponse != null)
                    {
                        accessToken = jsonResponse["access_token"]?.ToString() ?? "";
                    }
                }
            }

            return accessToken;
        }
    }
}
