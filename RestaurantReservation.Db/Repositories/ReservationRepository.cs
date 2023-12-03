using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.ServicesInterfaces;

namespace RestaurantReservation.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly RestaurantReservationDbContext _restaurantReservationDbContext;

        public ReservationRepository(RestaurantReservationDbContext dbContext)
        {
            _restaurantReservationDbContext = dbContext;
        }

        public async Task AddAsync(Reservation reservation)
        {
            _restaurantReservationDbContext.Add(reservation);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Reservation reservation)
        {
            _restaurantReservationDbContext.Remove(reservation);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _restaurantReservationDbContext.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetByIdAsync(int reservationId)
        {
            return await _restaurantReservationDbContext.Reservations.FindAsync(reservationId);
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            _restaurantReservationDbContext.Update(reservation);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            return await _restaurantReservationDbContext.Reservations
                .Where(reservation => reservation.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<Reservation> ListOrdersAndMenuItemsForAReservationAsync(int reservationId)
        {
            return await _restaurantReservationDbContext.Reservations
                        .Include(r => r.Orders)
                        .ThenInclude(o => o.OrderItems)
                        .FirstOrDefaultAsync(r => r.ReservationId == reservationId);
        }

        public async Task<IEnumerable<OrderItem>> ListOrderedMenuItemsForAReservationAsync(int reservationId)
        {
            return await _restaurantReservationDbContext.OrderItems
                        .Where(oi => oi.Order.ReservationId == reservationId)
                        .ToListAsync();
        }
    }
}