using DataAccessLayer.Models;

namespace BusinessLayer.Contracts
{
	public interface ITicketService
	{
		Ticket GetTicketById(Guid ticketId);
		IEnumerable<Ticket> GetAllTickets();
		IEnumerable<Ticket> GetMyTickets(Guid userId);
		Ticket GetMyTicketForEvent(Guid userId, Guid eventId);
		void AddTicket(Ticket ticket);
		void UpdateTicket(Ticket ticket);
		void DeleteTicket(Guid ticket);
	}


}
