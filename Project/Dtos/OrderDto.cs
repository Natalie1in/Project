namespace Project.Dtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderProductDto> Products { get; set; } = new();
    }
}
