namespace DataAccessLayer.Models.Notification
{
	public class AppNotification : BaseNotification
	{
		public string Message { get; set; }
		public Guid UserId { get; set; }
		public virtual User User { get; set; }

	}
}
