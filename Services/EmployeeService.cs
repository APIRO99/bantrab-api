using bantrab_api.Models;
using bantrab_api.Context;


public class EmployeeService: IEmployeeService {
  EmployeeContext context;

  public EmployeeService(EmployeeContext _context) {
    context = _context;
  }

  public IEnumerable<Employee> Get() {
    return context.Employees;
  }
  public async Task Create(Employee employee) {
    context.Add(employee);
    await context.SaveChangesAsync();
  }
  public async Task Update(int id, Employee employee) {
    var currentEmployee = context.Employees.Find(id);
    if (currentEmployee != null) {
      currentEmployee.NAME = employee.NAME;
      currentEmployee.ADDRESS = employee.ADDRESS;
      await context.SaveChangesAsync();
    }
  }
  
  public async Task Delete(int id) {
    var currentEmployee = context.Employees.Find(id);
    if (currentEmployee != null) {
      context.Remove(currentEmployee);
      await context.SaveChangesAsync();
    }
  }
}


public interface IEmployeeService {
  public IEnumerable<Employee> Get();
  public Task Create(Employee employee);
  public Task Update(int id, Employee employee);
  public Task Delete(int id);
}