using DataAccessLayer.Models;

namespace BusinessLayer.Contracts
{
	public interface IEventService
	{
		Event GetEventById(Guid eventId);
		IEnumerable<Event> GetEvents();
		IEnumerable<Event> GetMyEvents(Guid userId);
		void AddEvent(Event newEvent);
		void UpdateEvent(Event updatedEvent);
		void DeleteEvent(Guid eventId);

	}
}
