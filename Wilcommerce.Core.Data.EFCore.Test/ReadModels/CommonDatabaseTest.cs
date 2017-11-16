using System.Linq;
using Wilcommerce.Core.Common.Domain.Models;
using Wilcommerce.Core.Data.EFCore.ReadModels;
using Wilcommerce.Core.Data.EFCore.Test.Fixtures;
using Xunit;

namespace Wilcommerce.Core.Data.EFCore.Test.ReadModels
{
    public class CommonDatabaseTest : IClassFixture<CommonContextFixture>
    {
        private CommonContextFixture _fixture;

        private CommonDatabase _database;

        public CommonDatabaseTest(CommonContextFixture fixture)
        {
            _fixture = fixture;
            _database = new CommonDatabase(_fixture.Context);
        }

        [Fact]
        public void GeneralSettings_Must_Have_A_Record()
        {
            bool hasSettings = _database.Settings.Any();
            Assert.True(hasSettings);
        }

        [Fact]
        public void Users_Should_Have_AtLeast_One_Administrator()
        {
            var users = _database.Users;
            bool hasAdministrator = users.Any(u => u.Role == User.Roles.ADMINISTRATOR);

            Assert.True(hasAdministrator);
        }
    }
}
