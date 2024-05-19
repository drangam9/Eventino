namespace Frontend.Entities
{
	public class TicketModel
	{
		public Guid TicketId { get; set; }
		public Guid EventId { get; set; }
		public Guid UserId { get; set; }
		public string Type { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}
