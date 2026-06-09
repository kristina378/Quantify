using Microsoft.EntityFrameworkCore;
using Quantify.Core.Users;
using Quantify.Core.Models;

namespace Quantify.Core.Data;

public class QuantifyDbContext: DbContext
{
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Student> Students {get; set;}
    public DbSet<Tutor> Tutors {get; set;}

    public DbSet<MathTask> MathTasks { get; set; }
    public DbSet<Module> Modules { get; set; }

    public QuantifyDbContext(DbContextOptions<QuantifyDbContext> options) : base(options){}

}