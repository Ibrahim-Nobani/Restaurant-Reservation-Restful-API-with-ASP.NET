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
public class CustomersController : ControllerBase
{
    private readonly CustomerService _customerService;
    private readonly IMapper _mapper;
    private readonly ILogger<CustomersController> _logger;

    public CustomersController(CustomerService customerService, IMapper mapper, ILogger<CustomersController> logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto customerDto)
    {
        var customer = _mapper.Map<Customer>(customerDto);
        await _customerService.CreateCustomerAsync(customer);
        return Ok(customer);
    }

    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetCustomerById(int customerId)
    {
        var customer = await _customerService.GetCustomerByIdAsync(customerId);

        _logger.LogInformation($"Customer found: {customer.FirstName} {customer.LastName}");
        return Ok(customer);
    }

    [HttpDelete("{customerId}")]
    public async Task<IActionResult> DeleteCustomerById(int customerId)
    {
        var customer = await _customerService.GetCustomerByIdAsync(customerId);

        await _customerService.DeleteCustomerAsync(customer);
        _logger.LogInformation($"Customer: {customer.FirstName} {customer.LastName} with Id: {customer.CustomerId} has been deleted!");
        return NoContent();
    }

    [HttpPut("{customerId}")]
    public async Task<IActionResult> UpdateCustomerById(int customerId, [FromBody] UpdateCustomerDto updateCustomerDto)
    {
        var customer = await _customerService.GetCustomerByIdAsync(customerId);

        _mapper.Map(updateCustomerDto, customer);
        await _customerService.UpdateCustomerAsync(customer);
        return Ok(customer);
    }

    [HttpPatch("{customerId}")]
    public async Task<IActionResult> PartiallyUpdateCustomerById(int customerId, [FromBody] JsonPatchDocument<UpdateCustomerDto> patchDocument)
    {
        var customer = await _customerService.GetCustomerByIdAsync(customerId);

        var customerToPatch = _mapper.Map<UpdateCustomerDto>(customer);
        patchDocument.ApplyTo(customerToPatch);
        
        TryValidateModel(customerToPatch);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _mapper.Map(customerToPatch, customer);
        await _customerService.UpdateCustomerAsync(customer);
        return Ok(customer);
    }

    [HttpGet("party-size/{partySize}")]
    public async Task<IActionResult> getCustomerByPartySize(int partySize)
    {
        var customer = await _customerService.FindCustomerByPartySizeAsync(partySize);
        return Ok(customer);
    }
}