using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeZone.DAL.Data;
using TimeZone.DAL.Models;
using TimeZone.PL.Areas.Dashboard.ViewModels;
using TimeZone.PL.Helpers;

namespace TimeZone.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class PortfolioController : Controller
    {
        private readonly ApplicationDbContext Context;
        private readonly IMapper mapper;

        public PortfolioController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.Context = dbContext;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(mapper.Map<IEnumerable<PortfolioVM>>(Context.Portfolio.ToList()));
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PortfoiloFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);

            }
            var portfoilo = mapper.Map<Portfolio>(vm);
            Context.Add(portfoilo);
            Context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var service = Context.Portfolio.Find(id);
            if (service is null)
            {
                return NotFound();
            }
            var servicevm = mapper.Map<PortfoiloFormVM>(service);
            return View(servicevm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PortfoiloFormVM vm)
        {
            var service = Context.Portfolio.Find(vm.Id);
            if (service is null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            mapper.Map(vm, service);
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var service = Context.Services.Find(id);
            if (service is null)
            {

                return NotFound();
            }
            return View(mapper.Map<ServiceDetailsVM>(service));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var service = Context.Portfolio.Find(id);
            if (service is null)
            {
                return RedirectToAction(nameof(Index));
            }

           // FilesSetting.Delete(service.ImgeName, "images");

            Context.Portfolio.Remove(service);
            Context.SaveChanges();
            return Ok(new { message = "service deleted" });
        }

    }
}
