using Microsoft.EntityFrameworkCore;
using System;
using Wilcommerce.Core.Common.Domain.Models;

namespace Wilcommerce.Core.Data.EFCore.Test.Fixtures
{
    public class CommonContextFixture : IDisposable
    {
        public CommonContext Context { get; protected set; }

        public CommonContextFixture()
        {
            BuildContext();
            PrepareData();
        }

        public void Dispose()
        {
            CleanData();
            if (Context != null)
            {
                Context.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        protected virtual void PrepareData()
        {
            var administrator = User.CreateAsAdministrator("Administrator", "admin@wilcommerce.com", "123");
            Context.Users.Add(administrator);

            var settings = GeneralSettings.Create("Wilcommerce", "it-IT", "EUR", "info@wilcommerce.com");
            Context.Settings.Add(settings);

            Context.SaveChanges();
        }

        protected virtual void CleanData()
        {
            Context.Users.RemoveRange(Context.Users);
            Context.Settings.RemoveRange(Context.Settings);
        }

        protected virtual void BuildContext()
        {
            var options = new DbContextOptionsBuilder<CommonContext>()
                .UseInMemoryDatabase(databaseName: "InMemory-Common")
                .Options;

            Context = new CommonContext(options);
        }
    }
}
