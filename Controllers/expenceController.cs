using Microsoft.AspNetCore.Mvc;
using SUM.Models;

namespace SUM.Controllers
{
    [ApiController]
    [Route("expences")]
    public class expenceController : ControllerBase
    {
        private readonly sumAppContext _context;

        public expenceController(sumAppContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult AddExpence(Expence expence)
        {
            _context.Expences.Add(expence);
            _context.SaveChanges();
            return Ok(expence);  
        }

        // GET /api/expences
        [HttpGet]
        public IActionResult GetExpences()
        {
            var expences = _context.Expences.ToList();
            return Ok(expences); 
        }
    }
}
