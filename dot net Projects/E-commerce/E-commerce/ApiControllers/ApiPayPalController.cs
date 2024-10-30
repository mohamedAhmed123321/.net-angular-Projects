using Azure;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]/[action]")]
public class ApiPayPalController : ControllerBase
{
    private readonly ClsPayPal _payPalService;

    public ApiPayPalController(ClsPayPal payPalService)
    {
        _payPalService = payPalService;
    }

    // Endpoint to create an order
    [HttpPost]
    public async Task<ApiResponseModel<string>> CreateOrder([FromBody] decimal amount)
    {
        ApiResponseModel<string> response = new ApiResponseModel<string>();

        
        var order = await _payPalService.CreateOrder(amount);

        if (order != null)
        {
            response.IsSuccess = true;
            response.Data = new List<string>() { order.Id};
            return response;
        }
        response.IsSuccess = false;
        return response;
    }

    // Endpoint to capture payment
    [HttpPost]
    public async Task<ApiResponseModel<string>> CapturePayment([FromBody] string orderId)
    {
        var capturedOrder = await _payPalService.CapturePayment(orderId);
        ApiResponseModel<string> response = new ApiResponseModel<string>();
        if (capturedOrder != null && capturedOrder.Status == "COMPLETED")
        {
       
            response.IsSuccess = true;
            response.Data = new List<string> { "Payment Captured" };
            return response;
        }
        response.IsSuccess = false;
        return response;
    }
}
