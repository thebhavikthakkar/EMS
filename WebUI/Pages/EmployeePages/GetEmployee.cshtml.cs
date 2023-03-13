using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebUI.Model;

namespace WebUI.Pages.EmployeePages
{
    public class GetEmployeeModel : PageModel
    {
        public EmployeeListModel employeeList { get; set; }

        public void OnGet(int? PageNumber,int? PageSize)
        {
            //Fetching the data
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(StaticVariable.url+"?PageNumber="+PageNumber+"&PageSize="+PageSize).Result;
            employeeList = response.Content.ReadFromJsonAsync<EmployeeListModel>().Result;
            
        }
    }
}
