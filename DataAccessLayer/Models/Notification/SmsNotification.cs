namespace DataAccessLayer.Models.Notification
{
	internal class SmsNotification : BaseNotification
	{
		public string PhoneNumber { get; set; }
		public string Message { get; set; }
	}
}
