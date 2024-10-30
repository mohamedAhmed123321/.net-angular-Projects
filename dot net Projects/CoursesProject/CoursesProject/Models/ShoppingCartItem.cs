namespace CoursesProject.Models
{
    public class ShoppingCartItem
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string ImageName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
