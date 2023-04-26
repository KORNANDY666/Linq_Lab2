using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Linq_Lab2.Models;

namespace Linq_Lab2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Linq_Lab2.Models.Student> Student { get; set; } = default!;
        public DbSet<Linq_Lab2.Models.Teacher> Teacher { get; set; } = default!;
        public DbSet<Linq_Lab2.Models.SchoolClass> SchoolClass { get; set; } = default!;
        public DbSet<Linq_Lab2.Models.Course> Course { get; set; } = default!;
        public DbSet<Linq_Lab2.Models.SchoolConnection> SchoolConnection { get; set; } = default!;
    }
}