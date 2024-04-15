using AutoMapper;
using RestaurantReservation.API.ModelsDto;
using RestaurantReservation.Db.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<Customer, CreateCustomerDto>();
        CreateMap<UpdateCustomerDto, Customer>();
        CreateMap<Customer, UpdateCustomerDto>();

        CreateMap<CreateEmployeeDto, Employee>();
        CreateMap<Employee, CreateEmployeeDto>();
        CreateMap<UpdateEmployeeDto, Employee>();
        CreateMap<Employee, UpdateEmployeeDto>();

        CreateMap<CreateRestaurantDto, Restaurant>();
        CreateMap<Restaurant, CreateRestaurantDto>();
        CreateMap<UpdateRestaurantDto, Restaurant>();
        CreateMap<Restaurant, UpdateRestaurantDto>();

        CreateMap<CreateMenuItemDto, MenuItem>();
        CreateMap<MenuItem, CreateMenuItemDto>();
        CreateMap<UpdateMenuItemDto, MenuItem>();
        CreateMap<MenuItem, UpdateMenuItemDto>();

        CreateMap<CreateOrderItemDto, OrderItem>();
        CreateMap<OrderItem, CreateOrderItemDto>();
        CreateMap<UpdateOrderItemDto, OrderItem>();
        CreateMap<OrderItem, UpdateOrderItemDto>();

        CreateMap<CreateOrderDto, Order>();
        CreateMap<Order, CreateOrderDto>();
        CreateMap<UpdateOrderDto, Order>();
        CreateMap<Order, UpdateOrderDto>();

        CreateMap<CreateReservationDto, Reservation>();
        CreateMap<Reservation, CreateReservationDto>();
        CreateMap<UpdateReservationDto, Reservation>();
        CreateMap<Reservation, UpdateReservationDto>();

        CreateMap<CreateTableDto, Table>();
        CreateMap<Table, CreateTableDto>();
        CreateMap<UpdateTableDto, Table>();
        CreateMap<Table, UpdateTableDto>();
    }
}