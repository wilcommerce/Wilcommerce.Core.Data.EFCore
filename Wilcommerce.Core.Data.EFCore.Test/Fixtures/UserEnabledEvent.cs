using System;
using Wilcommerce.Core.Infrastructure;

namespace Wilcommerce.Core.Data.EFCore.Test.Fixtures
{
    public class UserEnabledEvent : DomainEvent
    {
        public Guid UserId { get; private set; }

        public UserEnabledEvent(Guid userId)
            : base(userId, typeof(UserEnabledEvent))
        {
            UserId = userId;
        }
    }
}
