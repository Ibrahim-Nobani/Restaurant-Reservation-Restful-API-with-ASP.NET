using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Exceptions;
using RestaurantReservation.ServicesInterfaces;

namespace RestaurantReservation.Services
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITableRepository _tableRepository;

        public ReservationService(IReservationRepository reservationRepository, IRestaurantRepository restaurantRepository, ICustomerRepository customerRepository, ITableRepository tableRepository)
        {
            _reservationRepository = reservationRepository;
            _restaurantRepository = restaurantRepository;
            _customerRepository = customerRepository;
            _tableRepository = tableRepository;
        }

        public async Task<Reservation> GetReservationByIdAsync(int reservationId)
        {
            return await _reservationRepository.GetByIdAsync(reservationId) ?? throw new NotFoundException($"Reservation with ID {reservationId} not found.");
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            var reservations = await _reservationRepository.GetAllAsync();

            if (reservations.IsNullOrEmpty())
            {
                throw new NotFoundException("The Reservations list is either Null or Empty");
            }

            return reservations;
        }

        public async Task CreateReservationAsync(Reservation reservation)
        {
            await ValidateRestaurantId(reservation.RestaurantId);
            await ValidateCustomerId(reservation.CustomerId);
            await ValidateTableId(reservation.TableId);

            await _reservationRepository.AddAsync(reservation);
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            await ValidateRestaurantId(reservation.RestaurantId);
            await ValidateCustomerId(reservation.CustomerId);
            await ValidateTableId(reservation.TableId);

            await _reservationRepository.UpdateAsync(reservation);
        }

        public async Task DeleteReservationAsync(Reservation reservation)
        {
            await _reservationRepository.DeleteAsync(reservation);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            var reservationsByCustomer = await _reservationRepository.GetReservationsByCustomerAsync(customerId);

            if (reservationsByCustomer.IsNullOrEmpty())
            {
                throw new NotFoundException("The Reservations list is either Null or Empty");
            }

            return reservationsByCustomer;
        }

        public async Task<Reservation> ListOrdersAndMenuItemsForReservation(int reservationId)
        {
            return await _reservationRepository.ListOrdersAndMenuItemsForAReservationAsync(reservationId) ?? throw new NotFoundException($"Reservation with ID {reservationId} not found.");
        }

        public async Task<IEnumerable<OrderItem>> ListOrderedMenuItemsForAReservation(int reservationId)
        {
            var orderedItems = await _reservationRepository.ListOrderedMenuItemsForAReservationAsync(reservationId);

            if(orderedItems.IsNullOrEmpty())
            {
                throw new NotFoundException("The Ordered Items list is either Null or Empty");
            }
            
            return orderedItems;
        }

        private async Task ValidateRestaurantId(int restaurantId)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(restaurantId) ?? throw new NotFoundException($"Restaurant with Id {restaurantId} cannot be found!");
        }

        private async Task ValidateCustomerId(int customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId) ?? throw new NotFoundException($"Customer with Id {customerId} cannot be found!");
        }

        private async Task ValidateTableId(int tableId)
        {
            var table = await _tableRepository.GetByIdAsync(tableId) ?? throw new NotFoundException($"Table with Id {tableId} cannot be found!");
        }
    }
}