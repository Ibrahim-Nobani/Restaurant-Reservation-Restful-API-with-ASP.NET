using RestaurantReservation.Db.Models;
using RestaurantReservation.Repositories;

namespace RestaurantReservation.ServicesInterfaces
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetReservationsByCustomerAsync(int customerId);
        Task<Reservation> ListOrdersAndMenuItemsForAReservationAsync(int reservationId);
        Task<IEnumerable<OrderItem>> ListOrderedMenuItemsForAReservationAsync(int reservationId);
    }
}