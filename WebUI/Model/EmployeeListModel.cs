namespace WebUI.Model;

public class EmployeeListModel
{
    public List<EmployeeModel> items { get; set; }
    public int pageNumber { get; set; }
    public int totalPages { get; set; }
    public int totalCount { get; set; }
    public bool hasPreviousPage { get; set; }
    public bool hasNextPage { get; set; }
}
