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
public class TablesController : ControllerBase
{
    private readonly TableService _tableService;
    private readonly IMapper _mapper;
    private readonly ILogger<TablesController> _logger;

    public TablesController(TableService tableService, IMapper mapper, ILogger<TablesController> logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _tableService = tableService ?? throw new ArgumentNullException(nameof(tableService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTables()
    {
        var tables = await _tableService.GetAllTablesAsync();
        return Ok(tables);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTable([FromBody] CreateTableDto tableDto)
    {
        var table = _mapper.Map<Table>(tableDto);
        await _tableService.CreateTableAsync(table);
        return Ok(table);
    }

    [HttpGet("{tableId}")]
    public async Task<IActionResult> GetTableById(int tableId)
    {
        var table = await _tableService.GetTableByIdAsync(tableId);

        _logger.LogInformation($"Table with ID: is {table.TableId} found!");
        return Ok(table);
    }

    [HttpDelete("{tableId}")]
    public async Task<IActionResult> DeleteTableById(int tableId)
    {
        var table = await _tableService.GetTableByIdAsync(tableId);

        await _tableService.DeleteTableAsync(table);
        _logger.LogInformation($"Table with Id: {table.TableId} has been deleted!");
        return NoContent();
    }

    [HttpPut("{tableId}")]
    public async Task<IActionResult> UpdateTableById(int tableId, [FromBody] UpdateTableDto updateTableDto)
    {
        var table = await _tableService.GetTableByIdAsync(tableId);

        _mapper.Map(updateTableDto, table);
        await _tableService.UpdateTableAsync(table);
        return Ok(table);
    }

    [HttpPatch("{tableId}")]
    public async Task<IActionResult> PartiallyUpdateTableById(int tableId, [FromBody] JsonPatchDocument<UpdateTableDto> patchDocument)
    {
        var table = await _tableService.GetTableByIdAsync(tableId);

        var tableToPatch = _mapper.Map<UpdateTableDto>(table);
        patchDocument.ApplyTo(tableToPatch);

        _mapper.Map(tableToPatch, table);
        await _tableService.UpdateTableAsync(table);
        return NoContent();
    }
}