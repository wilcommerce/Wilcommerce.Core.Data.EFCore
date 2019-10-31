using System;
using Wilcommerce.Core.Infrastructure;

namespace Wilcommerce.Core.Data.EFCore.Test.Fixtures
{
    public class UserDisabledEvent : DomainEvent
    {
        public Guid UserId { get; private set; }

        public UserDisabledEvent(Guid userId)
            : base(userId, typeof(User))
        {
            UserId = userId;
        }
    }
}
