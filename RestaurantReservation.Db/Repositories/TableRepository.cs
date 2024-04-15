using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.ServicesInterfaces;

namespace RestaurantReservation.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly RestaurantReservationDbContext _restaurantReservationDbContext;

        public TableRepository(RestaurantReservationDbContext dbContext)
        {
            _restaurantReservationDbContext = dbContext;
        }

        public async Task AddAsync(Table table)
        {
            _restaurantReservationDbContext.Add(table);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Table table)
        {
            _restaurantReservationDbContext.Remove(table);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Table>> GetAllAsync()
        {
            return await _restaurantReservationDbContext.Tables.ToListAsync();
        }

        public async Task<Table> GetByIdAsync(int tableId)
        {
            return await _restaurantReservationDbContext.Tables.FindAsync(tableId);
        }

        public async Task UpdateAsync(Table table)
        {
            _restaurantReservationDbContext.Update(table);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }
    }
}