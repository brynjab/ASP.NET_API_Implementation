using System.ComponentModel.DataAnnotations;

namespace ASPNET_API_Implementation.Models
{
    public class Order
    {
        public Order()
        {
            Customer = new Customer();
            Clerk = new Clerk();
            Products = new List<Product>();
        }

        public int Id { get; set; }
        [Required]
        
        public int Total_Price { get; set; }
        [Required]
       
        public DateTime Date { get; set; }
    
        public Customer Customer { get; set; }
        public Clerk Clerk { get; set; }
        public List<Product> Products { get; set; }
    }
}
