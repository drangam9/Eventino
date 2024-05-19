using BusinessLayer.Contracts;

namespace BusinessLayer.Services
{
	public class SingletonService : ISingletonService
	{
		private readonly DateTime _instanceCreationDate;

		public SingletonService()
		{
			_instanceCreationDate = DateTime.Now;
		}
		public DateTime GetInstanceCreationTime()
		{
			return _instanceCreationDate;
		}
	}
}
