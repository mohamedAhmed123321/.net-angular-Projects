namespace E_commerce.Models
{
    public class FilteredItemsRequestModel
    {
        public int PageNumber { get; set; } = 1;
        public int Count { get; set; } = 12;
        public string Title { get; set; }
        public int? RamSize { get; set; }
        public string CategoryName { get; set; }
        public float? MinPrice { get; set; }
        public float? MaxPrice { get; set; }
    }
}
