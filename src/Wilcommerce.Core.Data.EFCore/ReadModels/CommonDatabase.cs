using System.Linq;
using Wilcommerce.Core.Common.Domain.Events;
using Wilcommerce.Core.Common.Domain.Models;
using Wilcommerce.Core.Common.Domain.ReadModels;

namespace Wilcommerce.Core.Data.EFCore.ReadModels
{
    public class CommonDatabase : ICommonDatabase
    {
        protected CommonContext _context = new CommonContext();

        public IQueryable<EventWrapper> Events => _context.Events;

        public IQueryable<GeneralSettings> Settings => _context.Settings;

        public IQueryable<User> Users => _context.Users;
    }
}
