namespace DataAccessLayer.Models.Notification
{
	public class EmailNotification : BaseNotification
	{
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }

	}
}
