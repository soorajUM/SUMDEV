using Microsoft.AspNetCore.Mvc;
using SUM.Models;

namespace SUM.Controllers
{
    [Route("Expenses")]
    public class ExpenseController : Controller
    {
        private readonly ExpenseContext _context;

        public ExpenseController(ExpenseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var expenses = _context.Expenses.ToList();
            return View("Expense", expenses); // Render Razor View
        }
    }
}
