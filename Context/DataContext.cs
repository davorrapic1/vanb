using Microsoft.EntityFrameworkCore;
using Models;

namespace Context
{
    public class DataContext : DbContext
    {
        // greška SQLite-a Unable to create an object of type 'DataContext'. For the different patterns supported at design time,
        // rješenje je staviti prazan ctr. Trenutno ne znam zašto but it works on my machine
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TecajRazmjene> TecajiRazmjene { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=hnb.db");
        }
    }
}