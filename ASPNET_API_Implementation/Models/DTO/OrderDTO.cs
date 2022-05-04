namespace ASPNET_API_Implementation.Models.DTO
{
    public class OrderDTO
    {
        public OrderDTO()
        {
            Customer = new Customer();
            Clerk = new Clerk();
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public int Total_Price { get; set; }
        public DateTime Date { get; set; }

        public Customer Customer { get; set; }
        public Clerk Clerk { get; set; }
        public List<Product> Products { get; set; }
    }
}
