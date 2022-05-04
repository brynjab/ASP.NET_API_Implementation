using ASPNET_API_Implementation.Models;
using ASPNET_API_Implementation.Models.DTO;

namespace ASPNET_API_Implementation.Data.Interfaces
{
    public interface IRepository
    {
        Task CreateClerkAsync(Clerk clerk);
        Task CreateCustomerAsync(Customer customer);
        Task CreateOrderAsync(Order order);
        Task CreateProductAsync(Product product);

        Task<List<ClerkDTO>> GetAllClerksAsync();
        Task<ClerkDTO> GetClerkByIdAsync(int id);
        Task<List<CustomerDTO>> GetAllCustomersAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(int id);
        Task<List<OrderDTO>> GetAllOrdersAsync();
        Task<OrderDTO> GetOrderByIdAsync(int id);
        Task<List<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);

        Task<Clerk> UpdateClerkAsync(int id, Clerk clerk);
        Task<Customer> UpdateCustomerAsync(int id, Customer customer);
        Task<Order> UpdateOrderAsync(int id, Order order);
        Task<Product> UpdateProductAsync(int id, Product product);

        Task<bool> DeleteClerkAsync(int id);
        Task<bool> DeleteCustomerAsync(int id);
        Task<bool> DeleteOrderAsync(int id);
        Task<bool> DeleteProductAsync(int id);
        
        
    }
}
