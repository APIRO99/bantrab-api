using Microsoft.EntityFrameworkCore;
using bantrab_api.Models;

namespace bantrab_api.Context;
public class EmployeeContext: DbContext {

  public DbSet<Employee> Employees { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    optionsBuilder.UseOracle(
      @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.68.76)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));User Id=SYSTEM;Password=test;"
    );
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.Entity<Employee>(employee => {
      employee.ToTable("BANTRAB_EMPLOYEE");
      employee.HasKey(e => e.ID);
      employee.Property(e => e.NAME);
      employee.Property(e => e.ADDRESS);
    });
  }
}