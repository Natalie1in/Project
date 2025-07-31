using Project.Dtos;

namespace Project.ViewModels
{
    public class CustomerOrderPagedViewModel
    {
        public List<CustomerOrdersDto> Customers { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
