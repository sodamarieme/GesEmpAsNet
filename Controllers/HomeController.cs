using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GesEmpAspNet.Models;
using System.Linq;

namespace GesEmpAspNet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Departments(string? search, int page = 1)
    {
        // Sample data matching the screenshot
        var list = new List<Department>
        {
            new Department { Id = 1, Name = "Amadou Diallo", CreatedAt = new DateTime(2023,3,15), Status = "Épargne" },
            new Department { Id = 2, Name = "Amadou Diallo", CreatedAt = new DateTime(2023,3,15), Status = "Épargne" }
        };

        if (!string.IsNullOrWhiteSpace(search))
        {
            list = list.Where(d => d.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        var vm = new DepartmentsViewModel
        {
            Departments = list,
            Search = search,
            Page = page,
            PageSize = 10,
            Total = list.Count
        };

        return View(vm);
    }

    public IActionResult Employees(string? search, string? typeFilter, string? sortBy, int page = 1)
    {
        var list = new List<Account>
        {
            new Account { AccountNumber = "C00123456", Holder = "Amadou Diallo", Type = "Épargne", Balance = 1250000m, CreatedAt = new DateTime(2023,3,15), Status = "Bloqué (DO)" },
            new Account { AccountNumber = "C00123457", Holder = "Fatou Ndiaye", Type = "Chèque", Balance = 3750000m, CreatedAt = new DateTime(2023,1,2), Status = "Actif" },
            new Account { AccountNumber = "C00123458", Holder = "Moussa Sow", Type = "Épargne", Balance = 850000m, CreatedAt = new DateTime(2023,4,10), Status = "Actif" },
            new Account { AccountNumber = "C00123459", Holder = "Aissatou Diop", Type = "Chèque", Balance = 2100000m, CreatedAt = new DateTime(2023,2,22), Status = "Actif" }
        };

        if (!string.IsNullOrWhiteSpace(search))
        {
            list = list.Where(a => a.AccountNumber.Contains(search, StringComparison.OrdinalIgnoreCase) || a.Holder.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrWhiteSpace(typeFilter))
        {
            list = list.Where(a => a.Type.Equals(typeFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            if (sortBy == "date") list = list.OrderByDescending(a => a.CreatedAt).ToList();
            if (sortBy == "balance") list = list.OrderByDescending(a => a.Balance).ToList();
        }

        var vm = new AccountsViewModel
        {
            Accounts = list,
            Search = search,
            TypeFilter = typeFilter,
            SortBy = sortBy,
            Page = page,
            PageSize = 10,
            Total = list.Count
        };

        return View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
