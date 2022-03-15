using Microsoft.EntityFrameworkCore;
using System;
using TruckManager.Repository.Models;

namespace TruckManager.Repository
{
    public class Context :DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<TruckModel> TruckModel { get; set; }
    }
}
