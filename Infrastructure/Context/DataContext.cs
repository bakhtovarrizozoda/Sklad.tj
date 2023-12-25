using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
       // Database.EnsureCreated();
    }

    public DbSet<Branch> Branches { get; set; }
    public DbSet<BranchAccess> BranchAccesses { get; set; }
    public DbSet<Incoming> Incomings { get; set; }
    public DbSet<Outcoming> Outcomings { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Storage> Storages { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }

}