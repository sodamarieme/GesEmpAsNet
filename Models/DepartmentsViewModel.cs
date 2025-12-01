using System.Collections.Generic;

namespace GesEmpAspNet.Models
{
    public class DepartmentsViewModel
    {
        public List<Department> Departments { get; set; } = new List<Department>();
        public string? Search { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int Total { get; set; }
    }
}
