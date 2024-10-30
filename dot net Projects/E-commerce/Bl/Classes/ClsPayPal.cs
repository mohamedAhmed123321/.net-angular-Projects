using Microsoft.Extensions.Configuration;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class ClsPayPal
{
    private readonly PayPalHttpClient _client;

    public ClsPayPal(IConfiguration configuration)
    {
        string clientId = configuration["PayPal:ClientId"];
        string clientSecret = configuration["PayPal:ClientSecret"];
        string environment = configuration["PayPal:Environment"];

        PayPalEnvironment paypalEnvironment;

        if (environment == "sandbox")
        {
            paypalEnvironment = new SandboxEnvironment(clientId, clientSecret);
        }
        else
        {
            paypalEnvironment = new LiveEnvironment(clientId, clientSecret);
        }

        _client = new PayPalHttpClient(paypalEnvironment);
    }

    // Create an order
    public async Task<Order> CreateOrder(decimal amount)
    {
        var orderRequest = new OrderRequest
        {
            CheckoutPaymentIntent = "CAPTURE",
            PurchaseUnits = new List<PurchaseUnitRequest>
            {
                new PurchaseUnitRequest
                {
                    AmountWithBreakdown = new AmountWithBreakdown
                    {
                        CurrencyCode = "USD",
                        Value = amount.ToString("F")
                    }
                }
            }
        };

        var request = new OrdersCreateRequest();
        request.Prefer("return=representation");
        request.RequestBody(orderRequest);

        var response = await _client.Execute(request);
        var statusCode = response.StatusCode;
        var result = response.Result<Order>();

        return result;
    }

    // Capture payment for an order
    public async Task<Order> CapturePayment(string orderId)
    {
        try
        {
            var request = new OrdersCaptureRequest(orderId);
            request.Prefer("return=representation");
            request.RequestBody(new OrderActionRequest());
            Console.WriteLine($"Request Body: {request.RequestBody}");

            var response = await _client.Execute(request);
            var statusCode = response.StatusCode;
            var result = response.Result<Order>();

            return result;
        }
        catch (PayPalHttp.HttpException ex)
        {
            // Log detailed error for debugging
            var errorMessage = $"Error capturing payment: {ex.Message}";

            Console.WriteLine($"Error Message: {errorMessage}");

            throw; // Re-throw the exception to be handled further up
        }
    }
}
