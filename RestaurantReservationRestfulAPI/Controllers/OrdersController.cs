using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.ModelsDto;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly OrderService _orderService;
    private readonly IMapper _mapper;
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(OrderService orderService, IMapper mapper, ILogger<OrdersController> logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);
        await _orderService.CreateOrderAsync(order);
        return Ok(order);
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderById(int orderId)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);

        _logger.LogInformation($"Order with ID: is {order.OrderId} found!");
        return Ok(order);
    }

    [HttpDelete("{orderId}")]
    public async Task<IActionResult> DeleteOrderById(int orderId)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);

        await _orderService.DeleteOrderAsync(order);
        _logger.LogInformation($"Order with Id: {order.OrderId} has been deleted!");
        return NoContent();
    }

    [HttpPut("{orderId}")]
    public async Task<IActionResult> UpdateOrderById(int orderId, [FromBody] UpdateOrderDto updateOrderDto)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);

        _mapper.Map(updateOrderDto, order);
        await _orderService.UpdateOrderAsync(order);
        return Ok(order);
    }

    [HttpPatch("{orderId}")]
    public async Task<IActionResult> PartiallyUpdateOrderById(int orderId, [FromBody] JsonPatchDocument<UpdateOrderDto> patchDocument)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);

        var orderToPatch = _mapper.Map<UpdateOrderDto>(order);
        patchDocument.ApplyTo(orderToPatch);

        _mapper.Map(orderToPatch, order);
        await _orderService.UpdateOrderAsync(order);
        return NoContent();
    }
}