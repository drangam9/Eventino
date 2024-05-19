using BusinessLayer.Contracts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EventController : Controller
	{
		private readonly IEventService _eventService;

		public EventController(IEventService eventService)
		{
			_eventService = eventService;
		}

		[HttpGet]
		[ResponseCache(Duration = 10, Location = ResponseCacheLocation.Client)]
		[SwaggerOperation(Summary = "Get all events")]
		public IActionResult GetEvents()
		{
			return Ok(_eventService.GetEvents().OrderByDescending(e => e.DateTime));
		}

		[HttpGet("{eventId}")]
		[SwaggerOperation(Summary = "Get an event by its Guid")]
		public IActionResult GetEventById([FromRoute] Guid eventId)
		{
			return Ok(_eventService.GetEventById(eventId));
		}

		[HttpPost]
		// For evaluation purposes, the role based authorization is commented out, so a user that's not an admin can add an event
		// [Authorize(Roles = "administrator")]

		[SwaggerOperation(Summary = "Add a new event")]
		public IActionResult AddEvent([FromBody] EventDto newEvent)
		{
			if (newEvent == null)
				return BadRequest("Event is null.");
			try
			{
				TimeSpan.Parse(newEvent.Duration);
			}
			catch
			{
				return BadRequest("Duration is not in the correct format. Format is [d'.']hh':'mm':'ss['.'fffffff]");
			}

			var addEvent = new Event
			{
				Title = newEvent.Title,
				Description = newEvent.Description,
				DateTime = newEvent.DateTime,
				Location = newEvent.Location,
				Duration = TimeSpan.Parse(newEvent.Duration),
				OrganizerId = newEvent.OrganizerId,
				Price = newEvent.Price
			};

			_eventService.AddEvent(addEvent);
			return Ok();
		}

		[HttpPut]
		[Authorize(Roles = "administrator")]
		[SwaggerOperation(Summary = "Update an event")]
		public IActionResult UpdateEvent([FromBody] EventDto updatedEvent)
		{
			Event newEvent = new()
			{
				Title = updatedEvent.Title,
				Description = updatedEvent.Description,
				DateTime = updatedEvent.DateTime,
				Location = updatedEvent.Location,
				Duration = TimeSpan.Parse(updatedEvent.Duration),
				OrganizerId = updatedEvent.OrganizerId,
				Price = updatedEvent.Price
			};
			_eventService.UpdateEvent(newEvent);
			return Ok();
		}

		[HttpDelete("{eventId}")]
		[Authorize(Roles = "administrator")]
		[SwaggerOperation(Summary = "Delete an event")]
		public IActionResult DeleteEvent([FromRoute] Guid eventId)
		{
			_eventService.DeleteEvent(eventId);
			return Ok();
		}
	}
}
