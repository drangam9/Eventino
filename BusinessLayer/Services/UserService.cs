using BusinessLayer.Contracts;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;

namespace BusinessLayer.Services
{
	public class UserService : IUserService
	{
		private readonly IRepository<User> _userRepository;

		public UserService(IRepository<User> userRepository)
		{
			_userRepository = userRepository;
		}

		public User GetUserById(Guid userId)
		{
			return _userRepository.GetById(userId);
		}
		public Guid GetUserIdByEntraId(Guid entraId)
		{
			return _userRepository.Find(u => u.EntraOid == entraId).Select(u => u.UserId).FirstOrDefault();
		}

		public List<User> GetAllUsers()
		{
			return _userRepository.GetAllQueryable().ToList();
		}

		public void CreateUser(User user)
		{
			var userExists = _userRepository.Find(u => u.EntraOid == user.EntraOid).Any();
			if (userExists)
			{
				return;
			}
			_userRepository.Add(user);
			_userRepository.SaveChanges();
		}

		public void UpdateUser(User user)
		{

			_userRepository.Update(user);
			_userRepository.SaveChanges();
		}

		public void DeleteUser(Guid userId)
		{

			var user = _userRepository.GetById(userId);
			_userRepository.Remove(user);
			_userRepository.SaveChanges();
		}
	}

}
