namespace Project.Dtos
{
    public class UpdateOrderProductDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public short Quantity { get; set; }
    }
}
