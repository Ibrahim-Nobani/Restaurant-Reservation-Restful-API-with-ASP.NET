using RestaurantReservation.Db.Models;
using RestaurantReservation.Repositories;

namespace RestaurantReservation.ServicesInterfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> ListAllManagersAsync();
        Task<decimal> CalculateAverageOrderAmountAsync(int employeeId);
    }
}