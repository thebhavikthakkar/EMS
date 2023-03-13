using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.EmployeePages
{
    public class DeleteEmployeeModel : PageModel
    {
        public void OnPost(int id)
        {
            //Sending the data
            HttpClient client = new HttpClient();
            var result = client.DeleteAsync(StaticVariable.url + "/" + id);

            //Redirecting to List Page
            Response.Redirect("/EmployeePages/GetEmployee");
        }
        
    }
}
