using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.ServicesInterfaces;

namespace RestaurantReservation.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantReservationDbContext _restaurantReservationDbContext;

        public MenuItemRepository(RestaurantReservationDbContext dbContext)
        {
            _restaurantReservationDbContext = dbContext;
        }

        public async Task AddAsync(MenuItem menuItem)
        {
            _restaurantReservationDbContext.Add(menuItem);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(MenuItem menuItem)
        {
            _restaurantReservationDbContext.Remove(menuItem);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<MenuItem>> GetAllAsync()
        {
            return await _restaurantReservationDbContext.MenuItems.ToListAsync();
        }

        public async Task<MenuItem> GetByIdAsync(int menuItemId)
        {
            return await _restaurantReservationDbContext.MenuItems.FindAsync(menuItemId);
        }

        public async Task UpdateAsync(MenuItem menuItem)
        {
            _restaurantReservationDbContext.Update(menuItem);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }
    }
}