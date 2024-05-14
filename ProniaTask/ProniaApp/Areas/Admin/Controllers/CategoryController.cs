using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaApp.DataAccesLayer;
using ProniaApp.ViewModels.Category;
using ProniaApp.DataAccesLayer;
using ProniaApp.ViewModels.Category;
using ProniaApp.ViewModels.Sliders;
using ProniaApp.Models;


namespace ProniaApp.Areas.Admin.Controllers
{
    public class CategoryController(ProniaDbContext _context) : Controller
    {


        [Area("Admin")]


        public async Task<IActionResult> Index()
        {
            var data = await _context.Categories.Where(x => !x.IsDeleted).Select(s => new GetCategoryVM
            {
                Id = s.Id,
                Name = s.Namee,
            }).ToListAsync();
            return View(data);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            Category category = new Category
            {
                CreatedTime = DateTime.Now,
                Namee = vm.Name,
                IsDeleted = false
            };


            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}