using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Exceptions;
using RestaurantReservation.ServicesInterfaces;

namespace RestaurantReservation.Services
{
    public class RestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int restaurantId)
        {
            return await _restaurantRepository.GetByIdAsync(restaurantId) ?? throw new NotFoundException($"Restaurant with ID {restaurantId} not found.");
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            var restaurants = await _restaurantRepository.GetAllAsync();

            if (restaurants.IsNullOrEmpty())
            {
                throw new NotFoundException("The restaurants list is either Null or Empty");
            }

            return restaurants;
        }

        public async Task CreateRestaurantAsync(Restaurant restaurant)
        {
            await _restaurantRepository.AddAsync(restaurant);
        }

        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            await _restaurantRepository.UpdateAsync(restaurant);
        }

        public async Task DeleteRestaurantAsync(Restaurant restaurant)
        {
            await _restaurantRepository.DeleteAsync(restaurant);
        }

        public async Task<decimal> CalculateTotalRevenueByRestaurantAsync(int restaurantId)
        {
            return await _restaurantRepository.CalculateTotalRevenueByRestaurantAsync(restaurantId);
        }
    }
}