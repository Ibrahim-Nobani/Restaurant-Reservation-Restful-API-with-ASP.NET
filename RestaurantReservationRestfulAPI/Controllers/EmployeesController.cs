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
public class EmployeesController : ControllerBase
{
    private readonly EmployeeService _employeeService;
    private readonly IMapper _mapper;
    private readonly ILogger<EmployeesController> _logger;

    public EmployeesController(EmployeeService employeeService, IMapper mapper, ILogger<EmployeesController> logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return Ok(employees);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);
        await _employeeService.CreateEmployeeAsync(employee);
        return Ok(employee);
    }

    [HttpGet("{employeeId}")]
    public async Task<IActionResult> GetEmployeeById(int employeeId)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);

        _logger.LogInformation($"employee found: {employee.FirstName} {employee.LastName}");
        return Ok(employee);
    }

    [HttpDelete("{employeeId}")]
    public async Task<IActionResult> DeleteEmployeeById(int employeeId)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);

        await _employeeService.DeleteEmployeeAsync(employee);
        _logger.LogInformation($"employee: {employee.FirstName} {employee.LastName} with Id: {employee.EmployeeId} has been deleted!");
        return NoContent();
    }

    [HttpPut("{employeeId}")]
    public async Task<IActionResult> UpdateEmployeeById(int employeeId, [FromBody] UpdateEmployeeDto updateEmployeeDto)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);

        _mapper.Map(updateEmployeeDto, employee);
        await _employeeService.UpdateEmployeeAsync(employee);
        return Ok(employee);
    }

    [HttpPatch("{employeeId}")]
    public async Task<IActionResult> PartiallyUpdateEmployeeById(int employeeId, [FromBody] JsonPatchDocument<UpdateEmployeeDto> patchDocument)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);

        var employeeToPatch = _mapper.Map<UpdateEmployeeDto>(employee);
        patchDocument.ApplyTo(employeeToPatch);

        _mapper.Map(employeeToPatch, employee);
        await _employeeService.UpdateEmployeeAsync(employee);
        return NoContent();
    }

    [HttpGet("managers")]
    public async Task<IActionResult> ListAllManagers()
    {
        var managers = await _employeeService.ListAllManagersAsync();
        return Ok(managers);
    }

    [HttpGet("{employeeId}/average-order-amount")]
    public async Task<IActionResult> CalculateAverageOrderAmount(int employeeId)
    {
        var orderAmount = await _employeeService.CalculateAverageOrderAmountAsync(employeeId);

        return Ok(orderAmount);
    }
}