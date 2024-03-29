﻿using System.Threading;
using System.Threading.Tasks;
using datalayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace migrations
{
    public class Worker : IHostedService
    {
        private readonly IDbContextFactory<ApplicationDataContext> _context;

        public Worker(IDbContextFactory<ApplicationDataContext> context)
        {
            _context = context;
        }


        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var dbContext = _context.CreateDbContext())
            {
                await dbContext.Database.MigrateAsync(cancellationToken);
            }

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}