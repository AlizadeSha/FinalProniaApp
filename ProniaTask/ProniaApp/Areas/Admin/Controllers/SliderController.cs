using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaApp.DataAccesLayer;
using ProniaApp.Models;
using ProniaApp.ViewModels.Sliders;


namespace ProniaApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController(ProniaDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var data = await _context.Sliders.Where(x => !x.IsDeleted).Select(s => new GetSliderVM
            {
                Id = s.Id,
                SubTitle = s.SubTitle,
                Discount = s.Discount,     
                ImgUrl = s.ImgUrl,
                Title = s.Title
            }).ToListAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderVM vm)

        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            Slider slider = new Slider 
            {
            
                Discount = vm.Discount,
                ImgUrl = vm.ImgUrl,
                IsDeleted = false,
                SubTitle = vm.SubTitle,
                Title = vm.Title,
                CreatedTime=DateTime.Now,
          
        };
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
   
}