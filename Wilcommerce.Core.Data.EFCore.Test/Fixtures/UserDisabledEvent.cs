using System;
using Wilcommerce.Core.Infrastructure;

namespace Wilcommerce.Core.Data.EFCore.Test.Fixtures
{
    public class UserDisabledEvent : DomainEvent
    {
        public Guid UserDisabledId { get; private set; }

        public UserDisabledEvent(Guid userDisabledId, string userId)
            : base(userDisabledId, typeof(User), userId)
        {
            UserDisabledId = userDisabledId;
        }
    }
}
