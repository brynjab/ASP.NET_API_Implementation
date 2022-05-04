namespace ASPNET_API_Implementation.Models.DTO
{
    public class ProductDTO
    {
        public ProductDTO()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Unit_Price { get; set; }

        public List<Order> Orders { get; set; }
    }
}
