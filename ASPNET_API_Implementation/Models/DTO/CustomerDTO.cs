namespace ASPNET_API_Implementation.Models.DTO
{
    public class CustomerDTO
    {
        public CustomerDTO()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }


        public int CustomerNumber { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public List<Order> Orders { get; set; }
    }
}
