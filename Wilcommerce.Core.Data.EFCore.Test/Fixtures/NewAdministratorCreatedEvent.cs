using System;
using Wilcommerce.Core.Infrastructure;

namespace Wilcommerce.Core.Data.EFCore.Test.Fixtures
{
    public class NewAdministratorCreatedEvent : DomainEvent
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public NewAdministratorCreatedEvent(Guid userId, string name, string email)
            : base(userId ,typeof(User))
        {
            UserId = userId;
            Name = name;
            Email = email;
        }
    }
}
