namespace E_commerce.Models
{
    public class ApiResponseModel<T>
    {
        // data coming from api
        public List<T>? Data { get; set; }
        // list of api errors
        public string? Error { get; set; }
        public bool IsSuccess { get; set; }

    }
}
