using Microsoft.AspNetCore.Mvc;
using bantrab_api.Models;

namespace bantrab_api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase {
    IEmployeeService employeeService;
    public EmployeeController(IEmployeeService _employeeService) {
      employeeService = _employeeService;
    }

    [HttpGet]
    public IActionResult Get() {
      return Ok(employeeService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Employee employee){
      employeeService.Create(employee);
      return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody] Employee employee){
      employeeService.Update(employee.ID, employee);
      return Ok();
    }

    [HttpDelete]
    public IActionResult Delete([FromBody] Employee employee){
      employeeService.Delete(employee.ID);
      return Ok();
    }
}
