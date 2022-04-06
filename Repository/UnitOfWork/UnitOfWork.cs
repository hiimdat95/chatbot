using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _context;
        private bool disposed = false;
        protected readonly ILogger<IUnitOfWork> _logger;

        public UnitOfWork(TContext context, ILogger<IUnitOfWork> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">The disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // dispose the db context.
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        public async Task<int> SaveChangesAsync(bool ensureAutoHistory = false)
        {
            if (ensureAutoHistory)
            {
                _context.EnsureAutoHistory();
            }
            var currentDetectChangesSetting = _context.ChangeTracker.AutoDetectChangesEnabled;

            try
            {
                _context.ChangeTracker.AutoDetectChangesEnabled = false;
                _context.ChangeTracker.DetectChanges();

                var modifiedEntries = _context.ChangeTracker.Entries()
                    .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted);

                _context.ChangeTracker.DetectChanges();

                return await _context.SaveChangesAsync();
            }
            finally
            {
                _context.ChangeTracker.AutoDetectChangesEnabled = currentDetectChangesSetting;
            }
        }
    }
}