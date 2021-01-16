using System;
using Wilcommerce.Core.Infrastructure;

namespace Wilcommerce.Core.Data.EFCore.Test.Fixtures
{
    public class NewAdministratorCreatedEvent : DomainEvent
    {
        public Guid AdministratorId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public NewAdministratorCreatedEvent(Guid administratorId, string name, string email, string userId)
            : base(administratorId ,typeof(User), userId)
        {
            AdministratorId = administratorId;
            Name = name;
            Email = email;
        }
    }
}
