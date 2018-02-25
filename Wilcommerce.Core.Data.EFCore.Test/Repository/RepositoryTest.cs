using Microsoft.AspNetCore.Identity;
using Moq;
using System.Linq;
using Wilcommerce.Core.Common.Domain.Models;
using Wilcommerce.Core.Data.EFCore.ReadModels;
using Wilcommerce.Core.Data.EFCore.Test.Fixtures;
using Xunit;

namespace Wilcommerce.Core.Data.EFCore.Test.Repository
{
    public class RepositoryTest : IClassFixture<CommonContextFixture>
    {
        private CommonContextFixture _fixture;

        private EFCore.Repository.Repository _repository;

        private CommonDatabase _database;

        public RepositoryTest(CommonContextFixture fixture)
        {
            _fixture = fixture;
            _repository = new EFCore.Repository.Repository(_fixture.Context);
            _database = new CommonDatabase(_fixture.Context);
        }

        [Fact]
        public void Add_New_User_Should_Increment_Users_Number()
        {
            int usersCount = _database.Users.Count();

            var user = User.CreateAsAdministrator("Administrator2", "admin2@wilcommerce.com", "456", new Mock<IPasswordHasher<User>>().Object);
            _repository.Add(user);
            _repository.SaveChanges();

            int newUsersCount = _database.Users.Count();

            Assert.Equal(usersCount + 1, newUsersCount);
        }

        [Fact]
        public void GetByKey_Should_Return_The_User_Found()
        {
            var userId = _database.Users.FirstOrDefault(u => u.Email == "admin@wilcommerce.com").Id;

            var user = _repository.GetByKey<User>(userId);

            Assert.NotNull(user);
            Assert.Equal(userId, user.Id);
            Assert.Equal("admin@wilcommerce.com", user.Email);
        }
    }
}
