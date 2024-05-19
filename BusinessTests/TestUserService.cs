using BusinessLayer.Services;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Moq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BusinessTests
{
	[TestClass]
	public class TestUserService
	{
		[TestMethod]
		public void GetUserById_WhenCalled_ReturnsUser()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var entraId = Guid.NewGuid();
			var userRepositoryMock = new Mock<IRepository<User>>();
			userRepositoryMock.Setup(repo => repo.GetById(userId)).Returns(new User { UserId = userId, EntraOid = entraId, Email = "john@gmail.com", Name = "John" });

			var userService = new UserService(userRepositoryMock.Object);

			// Act
			var result = userService.GetUserById(userId);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(userId, result.UserId);
		}

		[TestMethod]
		public void GetAllUsers_WhenCalled_ReturnsAllUsers()
		{
			// Arrange

			var users = new List<User>
			{
				new User { UserId = Guid.NewGuid(), EntraOid = Guid.NewGuid(), Email = "", Name = "" },
				new User { UserId = Guid.NewGuid(), EntraOid = Guid.NewGuid(), Email = "", Name = "" }
			};

			var userRepositoryMock = new Mock<IRepository<User>>();
			userRepositoryMock.Setup(repo => repo.GetAllQueryable()).Returns(users.AsQueryable());

			var userService = new UserService(userRepositoryMock.Object);

			// Act
			var result = userService.GetAllUsers();

			//Asert
			Assert.IsNotNull(result);
			Assert.AreEqual(users.Count, result.Count);
			Assert.AreEqual(users[0].UserId, result[0].UserId);
			Assert.AreEqual(users[1].UserId, result[1].UserId);

		}
	}
}