using System.ComponentModel.DataAnnotations;

namespace bantrab_api.Models;

public class Employee {
  [Key]
  public int ID {get; set;}
  public string NAME {get;set;}
  public string ADDRESS {get;set;}
}

