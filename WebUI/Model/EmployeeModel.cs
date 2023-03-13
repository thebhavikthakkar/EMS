using System.ComponentModel;

namespace WebUI.Model;

public class EmployeeModel
{
    public int id { get; set; }
    [DisplayName("Name")]
    public string employeeName { get; set; }
    [DisplayName("Department")]
    public string department { get; set; }
    [DisplayName("Birthdate")]
    public DateTime dob { get; set; }
    [DisplayName("Email")]
    public string email { get; set; }
}
