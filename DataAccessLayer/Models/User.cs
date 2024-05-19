namespace DataAccessLayer.Models
{
	public class User
	{
		public Guid UserId { get; set; } = new Guid();
		public Guid EntraOid { get; set; }
		public string Email { get; set; } = "";
		public string Name { get; set; } = "";

		public ICollection<Event>? Events { get; set; }
		public ICollection<Ticket>? Tickets { get; set; }
		//public  OrganizerProfile OrganizerProfile { get; set; }
	}
}
