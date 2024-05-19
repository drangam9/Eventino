namespace DataAccessLayer.Models.Notification
{
	public abstract class BaseNotification
	{
		public Guid NotificationId { get; set; }
		public DateTime Date { get; set; }
		public string Status { get; set; }
	}
}
