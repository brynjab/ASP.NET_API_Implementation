using System.ComponentModel.DataAnnotations;

namespace ASPNET_API_Implementation.Models
{
    public class Product
    {
        public Product()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }
        [Required]
        
        public string Description { get; set; }
        [Required]
        
        public int Quantity { get; set; }
        [Required]
        public int Unit_Price { get; set; }

        public List<Order> Orders { get; set; }
    }
}
