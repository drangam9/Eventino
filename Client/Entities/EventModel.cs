namespace Frontend.Entities
{
	public class EventModel
	{

		public Guid EventId { get; set; }
		public Guid OrganizerId { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime DateTime { get; set; }

		public string Location { get; set; }

		public TimeSpan Duration { get; set; }

		public decimal Price { get; set; }

		public DateTime EndDate
		{
			get
			{
				return DateTime.Add(Duration);
			}
		}
	}


}
