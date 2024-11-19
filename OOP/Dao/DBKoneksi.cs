using Microsoft.EntityFrameworkCore;
using OOP.Models;

namespace OOP.Dao
{
    public class DBKoneksi : DbContext
    {
        public DBKoneksi(DbContextOptions<DBKoneksi> options) : base(options) 
        { 

        }
        public DbSet<Clients> Clients { get; set; }
    }
}
