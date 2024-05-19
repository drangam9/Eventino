using BusinessLayer.Contracts;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;

namespace BusinessLayer.Services
{
	public class EventService : IEventService
	{

		private readonly IRepository<Event> _eventRepository;

		public EventService(IRepository<Event> eventRepository)
		{
			_eventRepository = eventRepository;
		}

		public Event GetEventById(Guid eventId)
		{
			return _eventRepository.GetById(eventId);
		}

		public IEnumerable<Event> GetEvents()
		{
			return _eventRepository.GetAll();
		}

		public IEnumerable<Event> GetMyEvents(Guid userId)
		{
			return _eventRepository.Find(e => e.Tickets.FirstOrDefault(e => e.UserId == userId) != null);
		}
		public void AddEvent(Event newEvent)
		{

			_eventRepository.Add(newEvent);
			_eventRepository.SaveChanges();
		}

		public void UpdateEvent(Event updatedEvent)
		{
			_eventRepository.Update(updatedEvent);
			_eventRepository.SaveChanges();
		}

		public void DeleteEvent(Guid eventId)
		{
			var eventToDelete = _eventRepository.GetById(eventId);
			_eventRepository.Remove(eventToDelete);
			_eventRepository.SaveChanges();
		}

	}

}
