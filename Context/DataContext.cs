using Microsoft.EntityFrameworkCore;
using Models;

namespace vanb.Context
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base (options)
        { }


        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite ("Data Source=hnb.db");
        }
    }
}