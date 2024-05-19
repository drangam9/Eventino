using System.Text.Json.Serialization;

namespace DataAccessLayer.Models
{
	public class Ticket
	{
		public Guid TicketId { get; set; } = Guid.NewGuid();
		public Guid EventId { get; set; }
		public Guid UserId { get; set; }
		public string Type { get; set; } = "";
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		[JsonIgnore]
		public Event? Event { get; set; }
		public User? User { get; set; }
	}
}
