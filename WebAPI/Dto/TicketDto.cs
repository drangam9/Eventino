namespace WebAPI.Dto
{
	public class TicketDto
	{
		public Guid TicketId { get; set; } = Guid.NewGuid();
		public Guid EventId { get; set; }
		public Guid UserId { get; set; }
		public string Type { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}
