using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Model;

namespace WebUI.Pages.EmployeePages
{
    public class EditEmployeeModel : PageModel
    {
        public EmployeeModel employee { get; set; }
        public void OnGet(int id)
        {
            //Fetching the data
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(StaticVariable.url + "?PageNumber=1&PageSize=10").Result;
            var employeeList = response.Content.ReadFromJsonAsync<EmployeeListModel>().Result;
            
            //binding the data with model
            employee = employeeList.items.Find(u => u.id == id);
          
        }
        public void OnPost(EmployeeModel employee)
        {
            //Sending the data
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PutAsJsonAsync("https://localhost:7103/api/Employee/" + employee.id, employee).Result;


            //Redirecting to List Page
            Response.Redirect("/EmployeePages/GetEmployee");
        }
    }
}
