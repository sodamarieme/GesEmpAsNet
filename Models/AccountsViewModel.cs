using System.Collections.Generic;

namespace GesEmpAspNet.Models
{
    public class AccountsViewModel
    {
        public List<Account> Accounts { get; set; } = new List<Account>();
        public string? Search { get; set; }
        public string? TypeFilter { get; set; }
        public string? SortBy { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int Total { get; set; }
    }
}
