using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Exceptions;
using RestaurantReservation.ServicesInterfaces;

namespace RestaurantReservation.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RestaurantReservationDbContext _restaurantReservationDbContext;

        public EmployeeRepository(RestaurantReservationDbContext dbContext)
        {
            _restaurantReservationDbContext = dbContext;
        }

        public async Task AddAsync(Employee employee)
        {
            _restaurantReservationDbContext.Add(employee);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee employee)
        {
            _restaurantReservationDbContext.Remove(employee);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _restaurantReservationDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int employeeId)
        {
            return await _restaurantReservationDbContext.Employees.FindAsync(employeeId);
        }

        public async Task UpdateAsync(Employee employee)
        {
            _restaurantReservationDbContext.Update(employee);
            await _restaurantReservationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> ListAllManagersAsync()
        {
            return await _restaurantReservationDbContext.Employees
                .Where(employee => employee.Position == EmployeePositionEnum.Manager.ToString())
                .ToListAsync();
        }

        public async Task<decimal> CalculateAverageOrderAmountAsync(int employeeId)
        {
            var ordersByEmployee = await _restaurantReservationDbContext.Orders
                .Where(o => o.EmployeeId == employeeId)
                .ToListAsync();

            if (ordersByEmployee.IsNullOrEmpty())
            {
                throw new NotFoundException("No orders were found for this employee!");
            }

            decimal totalAmountSum = ordersByEmployee.Sum(o => o.TotalAmount);
            int ordersCount = ordersByEmployee.Count();
            return totalAmountSum / ordersCount;
        }
    }
}
