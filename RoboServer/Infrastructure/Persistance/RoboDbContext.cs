using System;
using System.Collections.Generic;
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Persistence;

public class RoboDbContext : DbContext
{
    public RoboDbContext(DbContextOptions<RoboDbContext> options) : base(options)
    {
    }

    public DbSet<Robot> Robots { get; set; }
}