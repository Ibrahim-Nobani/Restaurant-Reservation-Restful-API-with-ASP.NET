using RestaurantReservation.Db.Models;

namespace RestaurantReservation.ServicesInterfaces
{
    public interface IManagerService
    {
        IEnumerable<Employee> ListAllManagers();
    }
}