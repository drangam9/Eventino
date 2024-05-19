using BusinessLayer.Contracts;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;

namespace BusinessLayer.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;

        public TicketService(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Ticket GetTicketById(Guid ticketId)
        {
            return _ticketRepository.GetById(ticketId);
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _ticketRepository.GetAll();
        }

        public IEnumerable<Ticket> GetMyTickets(Guid userId)
        {
            return _ticketRepository.Find(e => e.UserId == userId);
        }
        public Ticket GetMyTicketForEvent(Guid userId, Guid eventId)
        {
            return _ticketRepository.Find(e => e.UserId == userId && e.EventId == eventId).FirstOrDefault();
        }

        public void AddTicket(Ticket newTicket)
        {
            _ticketRepository.Add(newTicket);
            _ticketRepository.SaveChanges();
        }

        public void UpdateTicket(Ticket updatedTicket)
        {
            _ticketRepository.Update(updatedTicket);
            _ticketRepository.SaveChanges();
        }

        public void DeleteTicket(Guid ticketId)
        {
            var ticketToDelete = _ticketRepository.GetById(ticketId);
            _ticketRepository.Remove(ticketToDelete);
            _ticketRepository.SaveChanges();
        }


    }
}
