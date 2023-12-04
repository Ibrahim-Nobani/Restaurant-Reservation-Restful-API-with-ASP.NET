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
public class ReservationsController : ControllerBase
{
    private readonly ReservationService _reservationService;
    private readonly IMapper _mapper;
    private readonly ILogger<ReservationsController> _logger;

    public ReservationsController(ReservationService reservationService, IMapper mapper, ILogger<ReservationsController> logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllReservations()
    {
        var reservations = await _reservationService.GetAllReservationsAsync();
        return Ok(reservations);
    }

    [HttpPost]
    public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto reservationDto)
    {
        var reservation = _mapper.Map<Reservation>(reservationDto);
        await _reservationService.CreateReservationAsync(reservation);
        return Ok(reservation);
    }

    [HttpGet("{reservationId}")]
    public async Task<IActionResult> GetReservationById(int reservationId)
    {
        var reservation = await _reservationService.GetReservationByIdAsync(reservationId);

        _logger.LogInformation($"Reservation with ID: is {reservation.ReservationId} found!");
        return Ok(reservation);
    }

    [HttpDelete("{reservationId}")]
    public async Task<IActionResult> DeleteReservationById(int reservationId)
    {
        var reservation = await _reservationService.GetReservationByIdAsync(reservationId);

        await _reservationService.DeleteReservationAsync(reservation);
        _logger.LogInformation($"Reservation with Id: {reservation.ReservationId} has been deleted!");
        return NoContent();
    }

    [HttpPut("{reservationId}")]
    public async Task<IActionResult> UpdateReservationById(int reservationId, [FromBody] UpdateReservationDto updateReservationDto)
    {
        var reservation = await _reservationService.GetReservationByIdAsync(reservationId);

        _mapper.Map(updateReservationDto, reservation);
        await _reservationService.UpdateReservationAsync(reservation);
        return Ok(reservation);
    }

    [HttpPatch("{reservationId}")]
    public async Task<IActionResult> PartiallyUpdateReservationById(int reservationId, [FromBody] JsonPatchDocument<UpdateReservationDto> patchDocument)
    {
        var reservation = await _reservationService.GetReservationByIdAsync(reservationId);

        var reservationToPatch = _mapper.Map<UpdateReservationDto>(reservation);
        patchDocument.ApplyTo(reservationToPatch);

        _mapper.Map(reservationToPatch, reservation);
        await _reservationService.UpdateReservationAsync(reservation);
        return NoContent();
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetReservationsByCustomer(int customerId)
    {
        var reservationsByCustomer = await _reservationService.GetReservationsByCustomerAsync(customerId);
        return Ok(reservationsByCustomer);
    }

    [HttpGet("{reservationId}/orders")]
    public async Task<IActionResult> ListOrdersAndMenuItemsForReservation(int reservationId)
    {
        var reservation = await _reservationService.ListOrdersAndMenuItemsForReservation(reservationId);
        return Ok(reservation);
    }

    [HttpGet("{reservationId}/menu-items")]
    public async Task<IActionResult> ListOrderedMenuItemsForAReservation(int reservationId)
    {
        var orderItems = await _reservationService.ListOrderedMenuItemsForAReservation(reservationId);
        return Ok(orderItems);
    }
}