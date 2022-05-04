using ASPNET_API_Implementation.Data.Interfaces;
using ASPNET_API_Implementation.Models;
using ASPNET_API_Implementation.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_API_Implementation.Data.Repository
{
    public class SalesRepository : IRepository
    {
        private readonly SalesDbContext _dbContext;

        public SalesRepository()
        {
            _dbContext = new SalesDbContext();
        }

        // HTTP GET
        public async Task<List<ClerkDTO>> GetAllClerksAsync()
        {
            List<Clerk> clerks;

            using(var db = _dbContext)
            {
                clerks = await db.Clerks.ToListAsync();
            }

            List<ClerkDTO> listToReturn = new List<ClerkDTO>();

            foreach(Clerk c in clerks)
            {
                ClerkDTO clerkToAdd = new ClerkDTO();

                clerkToAdd.Id = c.Id;
                clerkToAdd.Name = c.Name;

                listToReturn.Add(clerkToAdd);
            }
            return listToReturn;
        }

        public async Task<List<CustomerDTO>> GetAllCustomersAsync()
        {

            List<Customer> customers;

            using (var db = _dbContext)
            {
                customers = await db.Customers.ToListAsync();
            }

            List<CustomerDTO> listToReturn = new List<CustomerDTO>();

            foreach (Customer c in customers)
            {
                CustomerDTO customerToAdd = new CustomerDTO();

                customerToAdd.Id = c.Id;
                customerToAdd.Name = c.Name;
                customerToAdd.CustomerNumber = c.CustomerNumber;
                customerToAdd.Adress = c.Adress;

                listToReturn.Add(customerToAdd);
            }
            return listToReturn;
        }

        public async Task<List<OrderDTO>> GetAllOrdersAsync()
        {
            List<Order> orders;

            using(var db = _dbContext)
            {
                orders = await db.Orders.ToListAsync();
            }

            List<OrderDTO> listToReturn = new List<OrderDTO>();

            foreach (Order o in orders)
            {
                OrderDTO orderToAdd = new OrderDTO();

                orderToAdd.Id = o.Id;
                orderToAdd.Total_Price = o.Total_Price;
                orderToAdd.Date = o.Date;

                listToReturn.Add(orderToAdd);
            }
            return listToReturn;
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            List<Product> products;

            using(var db = _dbContext)
            {
                products = await db.Products.ToListAsync();
            }

            List<ProductDTO> listToReturn = new List<ProductDTO>();

            foreach (Product p in products)
            {
                ProductDTO productToAdd = new ProductDTO();

                productToAdd.Id = p.Id;
                productToAdd.Description = p.Description;
                productToAdd.Quantity = p.Quantity;
                productToAdd.Unit_Price = p.Unit_Price;

                listToReturn.Add(productToAdd);
            }

            return listToReturn;
        }

        public async Task<ClerkDTO> GetClerkByIdAsync(int id)
        {
            Clerk c;

            using(var db = _dbContext)
            {
                c = await db.Clerks.FirstOrDefaultAsync(x => x.Id == id);
            }

            ClerkDTO clerkToReturn = new ClerkDTO();

            clerkToReturn.Id = c.Id;
            clerkToReturn.Name = c.Name;

            return clerkToReturn;
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            Customer c;

            using( var db = _dbContext)
            {
                c = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            }

            CustomerDTO customerToReturn = new CustomerDTO();

            customerToReturn.Id = c.Id;
            customerToReturn.Name = c.Name;
            customerToReturn.CustomerNumber = c.CustomerNumber;
            customerToReturn.Adress = c.Adress;

            return customerToReturn;

        }

        public async Task<OrderDTO> GetOrderByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            Product p;
            
            using(var db = _dbContext)
            {
                p = await db.Products.FirstOrDefaultAsync(x => x.Id == id);
            }

            ProductDTO productToReturn = new ProductDTO();
            List<OrderDTO> ordersDTO = new List<OrderDTO>();

            foreach(Order o in p.Orders)
            {
                OrderDTO dto = new OrderDTO();

                dto.Id = o.Id;
                dto.Total_Price = o.Total_Price;
                dto.Date = o.Date;

                ordersDTO.Add(dto);
            }

            productToReturn.Id = p.Id;
            productToReturn.Unit_Price = p.Unit_Price;
            productToReturn.Quantity = p.Quantity;
            productToReturn.Description = p.Description;
            //productToReturn.Orders = ordersDTO;

            return productToReturn;
        }

        //HTTP POST
        public async Task CreateClerkAsync(Clerk clerk)
        {
            using(var db = _dbContext)
            {
                db.Clerks.AddAsync(clerk);
                db.SaveChangesAsync();
            }
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            using( var db = _dbContext)
            {
                await db.Customers.AddAsync(customer);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateOrderAsync(Order order)
        {
            using(var db = _dbContext)
            {
                await db.Orders.AddAsync(order);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateProductAsync(Product product)
        {
            using(var db = _dbContext)
            {
                await db.Products.AddAsync(product);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteClerkAsync(int id)
        {
            Clerk clerkToDelete;

            using(var db = _dbContext)
            {
                clerkToDelete = db.Clerks.FirstOrDefault(cl => cl.Id == id);

                if(clerkToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Clerks.Remove(clerkToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            Customer customerToDelete;

            using (var db = _dbContext)
            {
                customerToDelete = db.Customers.FirstOrDefault(c => c.Id == id);

                if(customerToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Customers.Remove(customerToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            Order orderToDelete;

            using( var db = _dbContext)
            {
                orderToDelete = db.Orders.FirstOrDefault(c => c.Id == id);
                
                if(orderToDelete == null) 
                { 
                    return false; 
                }
                else
                {
                    db.Orders.Remove(orderToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            Product productToDelete;

            using(var db = _dbContext)
            {
                productToDelete = db.Products.FirstOrDefault(c => c.Id == id);

                if(productToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Products.Remove(productToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        
        public async Task<Clerk> UpdateClerkAsync(int id, Clerk clerk)
        {
            using( var db = _dbContext)
            {
                Clerk clerkToUpdate = await db.Clerks.FirstOrDefaultAsync(c => c.Id == id);

                if(clerkToUpdate == null)
                {
                    return null;
                }

                clerkToUpdate.Name = clerk.Name;

                await db.SaveChangesAsync();
                return clerkToUpdate;
            }
        }

        public async Task<Customer> UpdateCustomerAsync(int id, Customer customer)
        {
            using(var db = _dbContext)
            {
                Customer customerToUpdate = await db.Customers.FirstOrDefaultAsync(c => c.Id == id);

                if(customerToUpdate == null)
                {
                    return null;
                }

                customerToUpdate.Name = customer.Name;
                customerToUpdate.CustomerNumber = customer.CustomerNumber;
                customerToUpdate.Adress = customer.Adress;

                await db.SaveChangesAsync();
                return customerToUpdate;
            }
        }

        public async Task<Order> UpdateOrderAsync(int id, Order order)
        {
            using(var db = _dbContext)
            {
                Order orderToUpdate = await db.Orders.FirstOrDefaultAsync(c => c.Id == id);

                if(orderToUpdate == null)
                {
                    return null;
                }

                orderToUpdate.Date = order.Date;
                orderToUpdate.Total_Price = order.Total_Price;

                await db.SaveChangesAsync();
                return orderToUpdate;
            }
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            using(var db = _dbContext)
            {
                Product productToUpdate = await db.Products.FirstOrDefaultAsync(c => c.Id == id);

                if(productToUpdate == null)
                {
                    return null;
                }

                productToUpdate.Unit_Price = product.Unit_Price;
                productToUpdate.Quantity = product.Quantity;
                productToUpdate.Description = product.Description;

                await db.SaveChangesAsync();
                return productToUpdate;
            }
        }
    }
}
