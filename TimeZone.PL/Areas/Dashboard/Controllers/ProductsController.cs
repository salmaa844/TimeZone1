using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeZone.DAL.Data;
using TimeZone.DAL.Models;
using TimeZone.PL.Areas.Dashboard.ViewModels;
using TimeZone.PL.Helpers;

namespace TimeZone.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext Context;
        private readonly IMapper mapper;


        public ProductsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.Context = dbContext;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(mapper.Map<IEnumerable<ProductVM>>(Context.Products.ToList()));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);

            }
            vm.ImgeName = FilesSetting.UploadeFile(vm.Image, "products");
            var service = mapper.Map<Product>(vm);
            Context.Add(service);
            Context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = Context.Products.Find(id);
            if (product is null)
            {
                return NotFound();
            }
            var productvm = mapper.Map<ProductFormVM>(product);
            return View(productvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductFormVM vm)
        {
            var product = Context.Products.Find(vm.Id);
            if (product is null)
            {
                return NotFound();
            }

            if (vm.Image != null)
            {
                // Ensure the file is not being used before deleting
                try
                {
                    FilesSetting.Delete(product.ImgeName, "products");
                }
                catch (IOException ex)
                {
                    // Log the exception or return a message to the user
                    ModelState.AddModelError("", "The image could not be deleted as it is being used by another process.");
                    return View(vm);
                }

                vm.ImgeName = FilesSetting.UploadeFile(vm.Image, "products");
            }
            else
            {
                ModelState.Remove("Image");
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            mapper.Map(vm, product);
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = Context.Products.Find(id);
            if (product is null)
            {

                return NotFound();
            }
            return View(mapper.Map<ProductDetailsVM>(product));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var service = Context.Products.Find(id);
            if (service is null)
            {
                return RedirectToAction(nameof(Index));
            }

            FilesSetting.Delete(service.ImgeName, "products");

            Context.Products.Remove(service);
            Context.SaveChanges();
            return Ok(new { message = "product deleted" });
        }
       
    }

}
