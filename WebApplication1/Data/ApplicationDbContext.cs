using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;
using WebApplication1.Data.ViewModel;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Nationality> Nationalities { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Data.ViewModel.DepartmentViewModel>? DepartmentViewModel { get; set; }

        public DbSet<WebApplication1.Data.ViewModel.EmployeeViewModel>? EmployeeViewModel { get; set; }
    }
}