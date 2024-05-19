using System.Text.Json.Serialization;

namespace DataAccessLayer.Models
{
	public class Event
	{
		public Guid EventId { get; set; } = new Guid();
		public string Title { get; set; } = "";
		public string Description { get; set; } = "";
		public string Location { get; set; } = "";
		public DateTime DateTime { get; set; }
		public TimeSpan Duration { get; set; }
		public Guid OrganizerId { get; set; }
		public decimal Price { get; set; }
		[JsonIgnore]
		public virtual User? Organizer { get; set; }
		public virtual ICollection<Ticket>? Tickets { get; set; }
		//public virtual ICollection<ReviewRating> ReviewsRatings { get; set; }

	}
}
