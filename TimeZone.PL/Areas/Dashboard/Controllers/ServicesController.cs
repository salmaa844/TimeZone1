﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeZone.DAL.Data;
using TimeZone.DAL.Models;
using TimeZone.PL.Areas.Dashboard.ViewModels;
using TimeZone.PL.Helpers;

namespace TimeZone.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext Context;
        private readonly IMapper mapper;

        public ServicesController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.Context = dbContext;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(mapper.Map<IEnumerable<ServiceVM>>(Context.Services.ToList()));
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);

            }
            vm.ImgeName = FilesSetting.UploadeFile(vm.Image, "images");
            var service = mapper.Map<Service>(vm);
            Context.Add(service);
            Context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var service = Context.Services.Find(id);
            if (service is null)
            {
                return NotFound();
            }
            var servicevm = mapper.Map<ServiceFormVM>(service);
            return View(servicevm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ServiceFormVM vm)
        {
            var service = Context.Services.Find(vm.Id);
            if (service is null)
            {
                return NotFound();
            }

            if (vm.Image != null)
            {
                // Ensure the file is not being used before deleting
                try
                {
                    FilesSetting.Delete(service.ImgeName, "images");
                }
                catch (IOException ex)
                {
                    // Log the exception or return a message to the user
                    ModelState.AddModelError("", "The image could not be deleted as it is being used by another process.");
                    return View(vm);
                }

                vm.ImgeName = FilesSetting.UploadeFile(vm.Image, "images");
            }
            else
            {
                ModelState.Remove("Image");
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
        
        [HttpPost ]
        public IActionResult Delete(int id)
        {
            var service = Context.Services.Find(id);
            if (service is null)
            {
                return RedirectToAction(nameof(Index));
            }

            FilesSetting.Delete(service.ImgeName, "images");

            Context.Services.Remove(service);
            Context.SaveChanges();
            return Ok(new {message="service deleted"});
        }

    }
}
