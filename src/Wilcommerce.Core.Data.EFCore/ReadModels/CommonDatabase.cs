﻿using System.Linq;
using Wilcommerce.Core.Common.Domain.Models;
using Wilcommerce.Core.Common.Domain.ReadModels;

namespace Wilcommerce.Core.Data.EFCore.ReadModels
{
    /// <summary>
    /// Implementation of <see cref="ICommonDatabase"/>
    /// </summary>
    public class CommonDatabase : ICommonDatabase
    {
        /// <summary>
        /// The DbContext instance
        /// </summary>
        protected CommonContext _context;

        /// <summary>
        /// Construct the common database
        /// </summary>
        /// <param name="context">The instance of the common context</param>
        public CommonDatabase(CommonContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get the list of settings
        /// </summary>
        public IQueryable<GeneralSettings> Settings => _context.Settings;

        /// <summary>
        /// Get the list of users
        /// </summary>
        public IQueryable<User> Users => _context.Users;
    }
}
