using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Exceptions;
using RestaurantReservation.ServicesInterfaces;

namespace RestaurantReservation.Services
{
    public class TableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IRestaurantRepository _restaurantRepository;

        public TableService(ITableRepository tableRepository, IRestaurantRepository restaurantRepository)
        {
            _tableRepository = tableRepository;
            _restaurantRepository = restaurantRepository;
        }

        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            return await _tableRepository.GetByIdAsync(tableId) ?? throw new NotFoundException($"Table with ID {tableId} not found."); ;
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            var tables = await _tableRepository.GetAllAsync();

            if (tables.IsNullOrEmpty())
            {
                throw new NotFoundException("The Tables list is either Null or Empty");
            }

            return tables;
        }

        public async Task CreateTableAsync(Table table)
        {
            await ValidateRestaurantId(table.RestaurantId);
            await _tableRepository.AddAsync(table);
        }

        public async Task UpdateTableAsync(Table table)
        {
            await ValidateRestaurantId(table.RestaurantId);
            await _tableRepository.UpdateAsync(table);
        }

        public async Task DeleteTableAsync(Table table)
        {
            await _tableRepository.DeleteAsync(table);
        }

        private async Task ValidateRestaurantId(int restaurantId)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(restaurantId) ?? throw new NotFoundException($"Restaurant with Id {restaurantId} cannot be found!");
        }
    }
}
