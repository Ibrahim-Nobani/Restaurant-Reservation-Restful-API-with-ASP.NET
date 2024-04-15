using RestaurantReservation.Db.Models;
using RestaurantReservation.Repositories;

namespace RestaurantReservation.ServicesInterfaces
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        Task<decimal> CalculateTotalRevenueByRestaurantAsync(int restaurantId);
    }
}