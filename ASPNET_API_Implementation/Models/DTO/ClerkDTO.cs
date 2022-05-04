namespace ASPNET_API_Implementation.Models.DTO
{
    public class ClerkDTO
    {
        public ClerkDTO()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Order> Orders { get; set; }
    }
}
