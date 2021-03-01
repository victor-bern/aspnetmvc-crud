using Microsoft.EntityFrameworkCore;
using crud.Models;

namespace crud.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserViewModel> Users { get; set; }
    }
}