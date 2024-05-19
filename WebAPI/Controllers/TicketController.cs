using BusinessLayer.Contracts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IEventService _eventService;

        public TicketController(ITicketService ticketService, IEventService eventService)
        {
            _ticketService = ticketService;
            _eventService = eventService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all tickets")]
        public IActionResult GetTickets()
        {
            return Ok(_ticketService.GetAllTickets());
        }

        [HttpGet("{ticketId}")]
        [SwaggerOperation(Summary = "Get a ticket by its Guid")]
        public IActionResult GetTicketById([FromRoute] Guid ticketId)
        {
            return Ok(_ticketService.GetTicketById(ticketId));
        }

        [HttpGet("mytickets/{userId}")]
        [SwaggerOperation(Summary = "Get all tickets of a user by its Guid")]
        public IActionResult GetMyTickets([FromRoute] Guid userId)
        {

            var tickets = _ticketService.GetMyTickets(userId);
            var events = _eventService.GetEvents();
            var myTickets = tickets.Join(events, t => t.EventId, e => e.EventId, (t, e) => new
            {
                t.Quantity,
                t.Price,
                t.Type,
                e.DateTime,
                e.Title,
                e.Location
            });
            return Ok(myTickets);

        }

        [HttpGet("myticket/{userId}/{eventId}")]
        [SwaggerOperation(Summary = "Get a ticket of a user for an event by their Guids")]
        public IActionResult GetMyTicketForEvent([FromRoute] Guid userId, [FromRoute] Guid eventId)
        {
            var ticket = _ticketService.GetMyTicketForEvent(userId, eventId);
            if (ticket is null)
                return NotFound();
            return Ok(ticket);
        }

        [HttpGet("myevents/{userId}")]
        [SwaggerOperation(Summary = "Get all events where a user has a ticket")]
        public IActionResult GetMyEvents([FromRoute] Guid userId)
        {
            var tickets = _ticketService.GetMyTickets(userId);
            var events = _eventService.GetEvents();
            var myEvents = events.Where(e => tickets.Any(t => t.EventId == e.EventId));
            return Ok(myEvents);
        }

        [HttpPost]

        [SwaggerOperation(Summary = "Add a new ticket")]
        public IActionResult AddTicket([FromBody] TicketDto newTicket)
        {
            if (newTicket == null)
                return BadRequest("Ticket is null.");

            var addTicket = new Ticket
            {
                EventId = newTicket.EventId,
                UserId = newTicket.UserId,
                Type = newTicket.Type,
                Price = newTicket.Price,
                Quantity = newTicket.Quantity,
            };

            _ticketService.AddTicket(addTicket);
            return Ok();
        }
    }
}
