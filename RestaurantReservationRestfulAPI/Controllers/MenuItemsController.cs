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
public class MenuItemsController : ControllerBase
{
    private readonly MenuItemService _menuItemService;
    private readonly IMapper _mapper;
    private readonly ILogger<MenuItemsController> _logger;

    public MenuItemsController(MenuItemService menuItemService, IMapper mapper, ILogger<MenuItemsController> logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _menuItemService = menuItemService ?? throw new ArgumentNullException(nameof(menuItemService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMenuItems()
    {
        var menuItems = await _menuItemService.GetAllMenuItemsAsync();
        return Ok(menuItems);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateMenuItem([FromBody] CreateMenuItemDto menuItemDto)
    {
        var menuItem = _mapper.Map<MenuItem>(menuItemDto);
        await _menuItemService.CreateMenuItemAsync(menuItem);
        return Ok(menuItem);
    }

    [HttpGet("{menuItemId}")]
    public async Task<IActionResult> GetMenuItemById(int menuItemId)
    {
        var menuItem = await _menuItemService.GetMenuItemByIdAsync(menuItemId);

        _logger.LogInformation($"menuItem found: {menuItem.Name} with ID: {menuItem.MenuItemId}");
        return Ok(menuItem);
    }

    [HttpDelete("{menuItemId}")]
    public async Task<IActionResult> DeleteMenuItemById(int menuItemId)
    {
        var menuItem = await _menuItemService.GetMenuItemByIdAsync(menuItemId);

        await _menuItemService.DeleteMenuItemAsync(menuItem);
        _logger.LogInformation($"menuItem: {menuItem.Name} with Id: {menuItem.MenuItemId} has been deleted!");
        return NoContent();
    }

    [HttpPut("{menuItemId}")]
    public async Task<IActionResult> UpdateMenuItemById(int menuItemId, [FromBody] UpdateMenuItemDto updateMenuItemDto)
    {
        var menuItem = await _menuItemService.GetMenuItemByIdAsync(menuItemId);

        _mapper.Map(updateMenuItemDto, menuItem);
        await _menuItemService.UpdateMenuItemAsync(menuItem);
        return Ok(menuItem);
    }

    [HttpPatch("{menuItemId}")]
    public async Task<IActionResult> PartiallyUpdateMenuItemById(int menuItemId, [FromBody] JsonPatchDocument<UpdateMenuItemDto> patchDocument)
    {
        var menuItem = await _menuItemService.GetMenuItemByIdAsync(menuItemId);

        var menuItemToPatch = _mapper.Map<UpdateMenuItemDto>(menuItem);
        patchDocument.ApplyTo(menuItemToPatch);

        _mapper.Map(menuItemToPatch, menuItem);
        await _menuItemService.UpdateMenuItemAsync(menuItem);
        return NoContent();
    }
}