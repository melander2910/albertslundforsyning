using Microsoft.EntityFrameworkCore;
using AlbertslundForsyning.Entities;

namespace AlbertslundForsyning.Context
{
    public class EFCoreContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<DataReading> DataReadings {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // the database name is given with 'DataBase=AlbForsyningDB'. There is no need to create the database manually.
            optionsBuilder.UseSqlServer
            (
            @"Server=(localdb)\MSSQLLocalDB;
            Database=AlbForsyningDB;
            Trusted_Connection=True;
            MultipleActiveResultSets=true"
            );
        }
    }
}