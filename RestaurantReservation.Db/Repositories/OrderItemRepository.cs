using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.ServicesInterfaces;

namespace RestaurantReservation.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly RestaurantReservationDbContext _restaurantReservationDbContext;

        public OrderItemRepository(RestaurantReservationDbContext dbContext)
        {
            _restaurantReservationDbContext = dbContext;
        }

        public async Task AddAsync(OrderItem orderItem)
        {
            _restaurantReservationDbContext.Add(orderItem);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(OrderItem orderItem)
        {
            _restaurantReservationDbContext.Remove(orderItem);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _restaurantReservationDbContext.OrderItems.ToListAsync();
        }

        public async Task<OrderItem> GetByIdAsync(int orderItemId)
        {
            return await _restaurantReservationDbContext.OrderItems.FindAsync(orderItemId);
        }

        public async Task UpdateAsync(OrderItem orderItem)
        {
            _restaurantReservationDbContext.Update(orderItem);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }
    }
}