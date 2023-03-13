using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Model;

namespace WebUI.Pages.EmployeePages
{
    public class AddEmployeeModel : PageModel
    {
        public EmployeeModel employee { get; set; }

        public void OnGet() { }

        public void OnPost(EmployeeModel employee)
        {
            //Sending the data
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var result = client.PostAsJsonAsync(StaticVariable.url, employee).Result;

            //Redirecting to List Page
            Response.Redirect("/EmployeePages/GetEmployee");
        }
    }
}
