using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Exceptions;
using RestaurantReservation.ServicesInterfaces;

namespace RestaurantReservation.Services
{
    public class OrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMenuItemRepository _menuItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, IMenuItemRepository menuItemRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _menuItemRepository = menuItemRepository;
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
        {
            return await _orderItemRepository.GetByIdAsync(orderItemId) ?? throw new NotFoundException($"Order Item with ID {orderItemId} not found."); ;
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
        {
            var orderItems = await _orderItemRepository.GetAllAsync();

            if (orderItems.IsNullOrEmpty())
            {
                throw new NotFoundException("The OrderItems list is either Null or Empty");
            }

            return orderItems;
        }

        public async Task CreateOrderItemAsync(OrderItem orderItem)
        {
            await ValidateMenuItemId(orderItem.MenuItemId);
            await ValidateOrderId(orderItem.OrderId);

            await _orderItemRepository.AddAsync(orderItem);
        }

        public async Task UpdateOrderItemAsync(OrderItem orderItem)
        {
            await ValidateMenuItemId(orderItem.MenuItemId);
            await ValidateOrderId(orderItem.OrderId);

            await _orderItemRepository.UpdateAsync(orderItem);
        }

        public async Task DeleteOrderItemAsync(OrderItem orderItem)
        {
            await _orderItemRepository.DeleteAsync(orderItem);
        }

        private async Task ValidateMenuItemId(int menuItemId)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(menuItemId) ?? throw new NotFoundException($"Menu Item with Id {menuItemId} cannot be found!");
        }

        private async Task ValidateOrderId(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId) ?? throw new NotFoundException($"Order with Id {orderId} cannot be found!");
        }
    }
}