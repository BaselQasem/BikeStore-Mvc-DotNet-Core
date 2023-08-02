using AutoMapper;
using BikeStore.Classes;
using BikeStore.Models;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _category;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(ICategory category, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _category = category;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CategoriesList(TableQuery brandFiltered)
        {
            var ListcategoryViewModel = _mapper.Map<List<CategoryViewModel>>(await _category.GetCategories());
            var ordList = brandFiltered.Sorting == 1 ? ListcategoryViewModel.OrderByDescending(o => o.CategoryName) : ListcategoryViewModel.OrderBy(o => o.CategoryName);

            brandFiltered.PagesCount = ((ordList.Count() - 1) / 5) + 1;
            brandFiltered.PageSize = 5;

            ViewBag.Filtered = brandFiltered;

            return PartialView("_category", ordList.Skip((brandFiltered.PageNumber - 1) * 5).Take(5));
        }
        public ActionResult Create()
        {
            return PartialView("_Create", new CategoryViewModel());
        }


        [HttpPost]
        public async Task<ActionResult> Create(CategoryViewModel category)
        {
            
            if (ModelState.IsValid)
            {
                //Add Successfull
                await _category.InserCategory(_mapper.Map<Category>(category));
                await _unitOfWork.Commit();
            }
            else
            {
                //failed to Add
                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Unknown error");
                return View("Index");
            }
            return RedirectToAction("index", "Category");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return PartialView("_Edit", _mapper.Map<CategoryViewModel>(await _category.GetCategory(id)));
        }
        [HttpPost]
        public async Task<ActionResult> SaveEdit(CategoryViewModel category)
        {

            if (ModelState.IsValid)
            {
                //Save Successfull
                 _category.UpdateCategory(_mapper.Map<Category>(category));
                await _unitOfWork.Commit();
                return RedirectToAction("index", "Category");

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
             _category.DeleteCategory(await _category.GetCategory(id));
            await _unitOfWork.Commit();
            return RedirectToAction("index", "category");
        }
    }
}
