using RestaurantReservation.Db.Models;
using RestaurantReservation.Repositories;

namespace RestaurantReservation.ServicesInterfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> ListOrdersAndMenuItemsAsync(int reservationId);
    }
}