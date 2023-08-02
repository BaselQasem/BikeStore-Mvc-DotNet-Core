using AutoMapper;
using BikeStore.Classes;
using BikeStore.Models;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace BikeStore.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrand _brand;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public BrandController(IBrand brand, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _brand = brand;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<ActionResult> brandsList(TableQuery brandFiltered)
        {

            var ListbrandViewModel = _mapper.Map<IEnumerable<BrandViewModel>>(await _brand.GetBrands());
            var ordList = brandFiltered.Sorting == 1 ? ListbrandViewModel.OrderByDescending(o => o.BrandName) : ListbrandViewModel.OrderBy(o => o.BrandName);
            brandFiltered.PagesCount = ((ordList.Count() - 1) / 5) + 1;
            brandFiltered.PageSize = 5;
            ViewBag.Filtered = brandFiltered;
            return PartialView("_brands", ordList.Skip((brandFiltered.PageNumber - 1) * 5).Take(5));
        }

        public ActionResult Create()
        {
            return PartialView("_Create", new BrandViewModel());
        }


        [HttpPost]
        public async Task<ActionResult> Create(BrandViewModel brand)
        {
            //if(brand != null)
            //{
            if (ModelState.IsValid)
            {
                //Add Successfull
                await _brand.InserBrand(_mapper.Map<Brand>(brand));
                await _unitOfWork.Commit();
            }
            else
            {
                //failed to Add
                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Unknown error");
                return View("Index");
            }
            return RedirectToAction("index", "brand");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return PartialView("_Edit", _mapper.Map<BrandViewModel>(await _brand.GetBrand(id)));

        }
        [HttpPost]
        public async Task<ActionResult> SaveEdit(BrandViewModel brand)
        {

            if (ModelState.IsValid)
            {
                //Save Successfull
                 _brand.UpdateBrand(_mapper.Map<Brand>(brand));
                await _unitOfWork.Commit();
                return RedirectToAction("index", "brand");
            }
            else
            {
                //failed To Save
                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Unknown error");
                return View("Index");

            }

        }
        public async Task<IActionResult> Delete(int id)
        {
             _brand.DeleteBrand(await _brand.GetBrand(id));
            await _unitOfWork.Commit();
            return RedirectToAction("index", "brand");
        }
    }
}
