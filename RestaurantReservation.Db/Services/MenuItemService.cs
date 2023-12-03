using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Exceptions;
using RestaurantReservation.ServicesInterfaces;

namespace RestaurantReservation.Services
{
    public class MenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IRestaurantRepository _restaurantRepository;

        public MenuItemService(IMenuItemRepository menuItemRepository, IRestaurantRepository restaurantRepository)
        {
            _menuItemRepository = menuItemRepository;
            _restaurantRepository = restaurantRepository;
        }
        public async Task<MenuItem> GetMenuItemByIdAsync(int menuItemId)
        {
            return await _menuItemRepository.GetByIdAsync(menuItemId) ?? throw new NotFoundException($"Menu Item with ID {menuItemId} not found.");
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            var menuItems = await _menuItemRepository.GetAllAsync();

            if (menuItems.IsNullOrEmpty())
            {
                throw new NotFoundException("The MenuItems list is either Null or Empty");
            }

            return menuItems;
        }

        public async Task CreateMenuItemAsync(MenuItem menuItem)
        {
            await ValidateRestaurantId(menuItem.RestaurantId);
            await _menuItemRepository.AddAsync(menuItem);
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            await ValidateRestaurantId(menuItem.RestaurantId);
            await _menuItemRepository.UpdateAsync(menuItem);
        }

        public async Task DeleteMenuItemAsync(MenuItem menuItem)
        {
            await _menuItemRepository.DeleteAsync(menuItem);
        }

        private async Task ValidateRestaurantId(int restaurantId)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(restaurantId) ?? throw new NotFoundException($"Restaurant with Id {restaurantId} cannot be found!");
        }
    }
}