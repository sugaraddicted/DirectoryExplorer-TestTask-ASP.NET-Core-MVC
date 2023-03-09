using DirectoryExplorer.Data;
using DirectoryExplorer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace DirectoryExplorer.Controllers
{
    public class DirectoryController : Controller
    {
        private readonly ILogger<DirectoryController> _logger;
        private readonly DataContext _context;

        public DirectoryController(ILogger<DirectoryController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var directory = _context.Directories
                .Include(c => c.ParentDirectory)
                .Include(c => c.ChildDirectories)
                .FirstOrDefault(c => c.ParentDirectoryId == null);

            if (directory == null)
            {
                return NotFound();
            }

            return View(directory);
        }

        public IActionResult DirectoryDetails(int id, string name)
        {
            var directory = _context.Directories
                .Include(d => d.ChildDirectories)
                .FirstOrDefault(d => d.Id == id);

            if (directory == null)
            {
                return NotFound();
            }

            return View("Index", directory);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}