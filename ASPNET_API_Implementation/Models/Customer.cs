using System.ComponentModel.DataAnnotations;

namespace ASPNET_API_Implementation.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }

        [Required]
       
        public int CustomerNumber { get; set; }
        [Required]
      
        public string Name { get; set; }
        [Required]
      
        public string Adress { get; set; }

        public List<Order> Orders { get; set; }
    }
}
