using System;
using Wilcommerce.Core.Infrastructure;

namespace Wilcommerce.Core.Data.EFCore.Test.Fixtures
{
    public class UserEnabledEvent : DomainEvent
    {
        public Guid UserEnabledId { get; private set; }

        public UserEnabledEvent(Guid userEnabledId, string userId)
            : base(userEnabledId, typeof(User), userId)
        {
            UserEnabledId = userEnabledId;
        }
    }
}
