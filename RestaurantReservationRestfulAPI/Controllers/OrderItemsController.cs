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
public class OrderItemsController : ControllerBase
{
    private readonly OrderItemService _orderItemService;
    private readonly IMapper _mapper;
    private readonly ILogger<OrderItemsController> _logger;

    public OrderItemsController(OrderItemService orderItemService, IMapper mapper, ILogger<OrderItemsController> logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _orderItemService = orderItemService ?? throw new ArgumentNullException(nameof(orderItemService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrderItems()
    {
        var orderItems = await _orderItemService.GetAllOrderItemsAsync();
        return Ok(orderItems);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrderItem([FromBody] CreateOrderItemDto orderItemDto)
    {
        var orderItem = _mapper.Map<OrderItem>(orderItemDto);
        await _orderItemService.CreateOrderItemAsync(orderItem);
        return Ok(orderItem);
    }

    [HttpGet("{orderItemId}")]
    public async Task<IActionResult> GetOrderItemById(int orderItemId)
    {
        var orderItem = await _orderItemService.GetOrderItemByIdAsync(orderItemId);

        _logger.LogInformation($"OrderItem found with ID: {orderItem.OrderItemId}");
        return Ok(orderItem);
    }

    [HttpDelete("{orderItemId}")]
    public async Task<IActionResult> DeleteOrderItemById(int orderItemId)
    {
        var orderItem = await _orderItemService.GetOrderItemByIdAsync(orderItemId);

        await _orderItemService.DeleteOrderItemAsync(orderItem);
        _logger.LogInformation($"OrderItem with Id: {orderItem.OrderItemId} has been deleted!");
        return NoContent();
    }

    [HttpPut("{orderItemId}")]
    public async Task<IActionResult> UpdateOrderItemById(int orderItemId, [FromBody] UpdateOrderItemDto updateOrderItemDto)
    {
        var orderItem = await _orderItemService.GetOrderItemByIdAsync(orderItemId);

        _mapper.Map(updateOrderItemDto, orderItem);
        await _orderItemService.UpdateOrderItemAsync(orderItem);
        return Ok(orderItem);
    }

    [HttpPatch("{orderItemId}")]
    public async Task<IActionResult> PartiallyUpdateOrderItemById(int orderItemId, [FromBody] JsonPatchDocument<UpdateOrderItemDto> patchDocument)
    {
        var orderItem = await _orderItemService.GetOrderItemByIdAsync(orderItemId);

        var orderItemToPatch = _mapper.Map<UpdateOrderItemDto>(orderItem);
        patchDocument.ApplyTo(orderItemToPatch);

        _mapper.Map(orderItemToPatch, orderItem);
        await _orderItemService.UpdateOrderItemAsync(orderItem);
        return NoContent();
    }
}