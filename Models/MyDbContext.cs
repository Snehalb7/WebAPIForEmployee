using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace WebAPIForEmployee.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
