namespace Project.Dtos
{
    public class CustomerOrdersDto
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public List<OrderDto> Orders { get; set; } = new();
    }
}
