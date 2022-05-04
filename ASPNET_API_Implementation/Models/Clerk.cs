using System.ComponentModel.DataAnnotations;

namespace ASPNET_API_Implementation.Models
{
    public class Clerk
    {
        public Clerk()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }
        [Required]
      
        public string Name { get; set; }

        public List<Order> Orders { get; set; }
    }
}
