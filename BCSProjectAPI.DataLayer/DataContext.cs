using BCSProjectAPI.DataLayer.Entities;
using System.Data.Entity;

namespace BCSProjectAPI.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext() : base("BCSProject")
        {

        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        public DbSet<EmployeeLanguage> GetEmployeeLanguages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<EmployeeCharacteristic> EmployeeCharacteristics { get; set; }
    }
}
