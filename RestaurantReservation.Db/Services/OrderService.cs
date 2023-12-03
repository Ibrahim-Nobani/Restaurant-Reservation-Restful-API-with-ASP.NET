using RestaurantReservation.Db.Models;
using RestaurantReservation.Exceptions;
using RestaurantReservation.ServicesInterfaces;
using Microsoft.IdentityModel.Tokens;

namespace RestaurantReservation.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public OrderService(IOrderRepository orderRepository, IReservationRepository reservationRepository, IEmployeeRepository employeeRepository)
        {
            _orderRepository = orderRepository;
            _reservationRepository = reservationRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetByIdAsync(orderId) ?? throw new NotFoundException($"Order with ID {orderId} not found."); ;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            if (orders.IsNullOrEmpty())
            {
                throw new NotFoundException("The Orders list is either Null or Empty");
            }

            return orders;
        }

        public async Task CreateOrderAsync(Order order)
        {
            await ValidateReservationId(order.ReservationId);
            await ValidateEmployeeId(order.EmployeeId);

            await _orderRepository.AddAsync(order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await ValidateReservationId(order.ReservationId);
            await ValidateEmployeeId(order.EmployeeId);

            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(Order order)
        {
            await _orderRepository.DeleteAsync(order);
        }

        public async Task<IEnumerable<Order>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            return await _orderRepository.ListOrdersAndMenuItemsAsync(reservationId);
        }

        private async Task ValidateReservationId(int reservationId)
        {
            var reservation = await _reservationRepository.GetByIdAsync(reservationId) ?? throw new NotFoundException($"Reservation with Id {reservationId} cannot be found!");
        }

        private async Task ValidateEmployeeId(int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId) ?? throw new NotFoundException($"Employee with Id {employeeId} cannot be found!");
        }
    }
}