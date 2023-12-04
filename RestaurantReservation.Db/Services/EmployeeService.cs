using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Exceptions;
using RestaurantReservation.ServicesInterfaces;

namespace RestaurantReservation.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRestaurantRepository _restaurantRepository;


        public EmployeeService(IEmployeeRepository employeeRepository, IRestaurantRepository restaurantRepository)
        {
            _employeeRepository = employeeRepository;
            _restaurantRepository = restaurantRepository;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            return await _employeeRepository.GetByIdAsync(employeeId) ?? throw new NotFoundException($"Employee with ID {employeeId} not found.");
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            if (employees.IsNullOrEmpty())
            {
                throw new NotFoundException("The Employees list is either Null or Empty");
            }

            return employees;
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            await ValidateRestaurantId(employee.RestaurantId);
            await _employeeRepository.AddAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await ValidateRestaurantId(employee.RestaurantId);
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            await _employeeRepository.DeleteAsync(employee);
        }

        public async Task<IEnumerable<Employee>> ListAllManagersAsync()
        {
            var managers = await _employeeRepository.ListAllManagersAsync();

            if (managers.IsNullOrEmpty())
            {
                throw new NotFoundException("The Managers list is either Null or Empty");
            }

            return managers;
        }

        public async Task<decimal> CalculateAverageOrderAmountAsync(int employeeId)
        {
            return await _employeeRepository.CalculateAverageOrderAmountAsync(employeeId);
        }

        private async Task ValidateRestaurantId(int restaurantId)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(restaurantId) ?? throw new NotFoundException($"Restaurant with Id {restaurantId} cannot be found!");
        }
    }
}
