using EventManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagement.DataLayer
{
    public class EventManagementDbContext : DbContext
    {
        public EventManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

    }
}