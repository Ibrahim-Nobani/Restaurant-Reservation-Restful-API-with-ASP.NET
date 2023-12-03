using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.ServicesInterfaces;

namespace RestaurantReservation.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RestaurantReservationDbContext _restaurantReservationDbContext;

        public CustomerRepository(RestaurantReservationDbContext dbContext)
        {
            _restaurantReservationDbContext = dbContext;
        }

        public async Task AddAsync(Customer customer)
        {
            _restaurantReservationDbContext.Add(customer);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer customer)
        {
            _restaurantReservationDbContext.Remove(customer);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> FindCustomerByPartySizeAsync(int partySize)
        {
            var partySizeParameter = new SqlParameter("@PartySize", partySize);

            var query = "EXEC sp_FindCustomersByPartySize @PartySize";
            var customers = await _restaurantReservationDbContext.Set<Customer>().FromSqlRaw(query, partySizeParameter).ToListAsync();

            return customers;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _restaurantReservationDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int customerId)
        {
            return await _restaurantReservationDbContext.Customers.FindAsync(customerId);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _restaurantReservationDbContext.Update(customer);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }
    }
}
