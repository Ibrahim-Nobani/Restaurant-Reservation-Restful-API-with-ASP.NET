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
public class RestaurantsController : ControllerBase
{
    private readonly RestaurantService _restaurantService;
    private readonly IMapper _mapper;
    private readonly ILogger<RestaurantsController> _logger;

    public RestaurantsController(RestaurantService restaurantService, IMapper mapper, ILogger<RestaurantsController> logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _restaurantService = restaurantService ?? throw new ArgumentNullException(nameof(restaurantService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRestaurants()
    {
        var restaurants = await _restaurantService.GetAllRestaurantsAsync();
        return Ok(restaurants);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto restaurantDto)
    {
        var restaurant = _mapper.Map<Restaurant>(restaurantDto);
        await _restaurantService.CreateRestaurantAsync(restaurant);
        return Ok(restaurant);
    }

    [HttpGet("{restaurantId}")]
    public async Task<IActionResult> GetRestaurantById(int restaurantId)
    {
        var restaurant = await _restaurantService.GetRestaurantByIdAsync(restaurantId);

        _logger.LogInformation($"Restaurant found: {restaurant.Name} {restaurant.RestaurantId}");
        return Ok(restaurant);
    }

    [HttpDelete("{restaurantId}")]
    public async Task<IActionResult> DeleteRestaurantById(int restaurantId)
    {
        var restaurant = await _restaurantService.GetRestaurantByIdAsync(restaurantId);

        await _restaurantService.DeleteRestaurantAsync(restaurant);
        _logger.LogInformation($"restaurant with Id: {restaurant.RestaurantId} has been deleted!");
        return NoContent();
    }

    [HttpPut("{restaurantId}")]
    public async Task<IActionResult> UpdateRestaurantById(int restaurantId, [FromBody] UpdateRestaurantDto updateRestaurantDto)
    {
        var restaurant = await _restaurantService.GetRestaurantByIdAsync(restaurantId);

        _mapper.Map(updateRestaurantDto, restaurant);
        await _restaurantService.UpdateRestaurantAsync(restaurant);
        return Ok(restaurant);
    }

    [HttpPatch("{restaurantId}")]
    public async Task<IActionResult> PartiallyUpdateRestaurantById(int restaurantId, [FromBody] JsonPatchDocument<UpdateRestaurantDto> patchDocument)
    {
        var restaurant = await _restaurantService.GetRestaurantByIdAsync(restaurantId);

        var restaurantToPatch = _mapper.Map<UpdateRestaurantDto>(restaurant);
        patchDocument.ApplyTo(restaurantToPatch);

        _mapper.Map(restaurantToPatch, restaurant);
        await _restaurantService.UpdateRestaurantAsync(restaurant);
        return NoContent();
    }

    [HttpGet("{restaurantId}/total-revenue")]
    public async Task<IActionResult> getTotalRevenueForARestaurant(int restaurantId)
    {
        var totalRevenue = await _restaurantService.CalculateTotalRevenueByRestaurantAsync(restaurantId);
        return Ok(totalRevenue);
    }
}