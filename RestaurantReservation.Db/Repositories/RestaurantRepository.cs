using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.ServicesInterfaces;

namespace RestaurantReservation.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantReservationDbContext _restaurantReservationDbContext;

        public RestaurantRepository(RestaurantReservationDbContext dbContext)
        {
            _restaurantReservationDbContext = dbContext;
        }

        public async Task AddAsync(Restaurant restaurant)
        {
            _restaurantReservationDbContext.Add(restaurant);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Restaurant restaurant)
        {
            _restaurantReservationDbContext.Remove(restaurant);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            return await _restaurantReservationDbContext.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetByIdAsync(int restaurantId)
        {
            return await _restaurantReservationDbContext.Restaurants.FindAsync(restaurantId);
        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            _restaurantReservationDbContext.Update(restaurant);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task<decimal> CalculateTotalRevenueByRestaurantAsync(int restaurantId)
        {
            var restaurantIdParameter = new SqlParameter("@RestaurantId", restaurantId);

            var query = "EXEC @Value = dbo.CalculateTotalRevenueByRestaurant @RestaurantId";

            var totalRevenueParameter = new SqlParameter("@Value", SqlDbType.Decimal)
            {
                Direction = ParameterDirection.Output
            };

            await _restaurantReservationDbContext.Database.ExecuteSqlRawAsync(query, restaurantIdParameter, totalRevenueParameter);

            var totalRevenue = (decimal)totalRevenueParameter.Value;

            return totalRevenue;
        }
    }
}