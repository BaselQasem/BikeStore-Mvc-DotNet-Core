using AutoMapper;
using BikeStore.Classes;
using BikeStore.Models;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    public class StoreController : Controller
    {

        private readonly IStore _store;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        int pageSize = 5;
        public StoreController(IStore store, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _store = store;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> StoresList(TableQuery storeFiltered)
        {
            storeFiltered.PageSize = pageSize;
            storeFiltered.RowNumberStart = ((storeFiltered.PageNumber-1) * pageSize);

            var StoreWithCount =await _store.GetStoresFilter(storeFiltered);
            var ListStoreViewModel=_mapper.Map<List<StoreViewModel>>(StoreWithCount.Item1);
                   
            storeFiltered.PagesCount = StoreWithCount.Item2;
            storeFiltered.PageSize = 10;
            ViewBag.Filtered = storeFiltered;

            return PartialView("_store", ListStoreViewModel);
        }
        public ActionResult Create()
        {
            return PartialView("_Create", new StoreViewModel());
        }
        [HttpPost]
        public async Task<ActionResult> Create(StoreViewModel store)
        {
            if (ModelState.IsValid)
            {
                //Add Successfull
                await _store.InserStore(_mapper.Map<Store>(store));
                await _unitOfWork.Commit();
            }
            else
            {
                //failed to Add
                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Unknown error");
                return View("Index");
            }
            return RedirectToAction("index", "store");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return PartialView("_Edit", _mapper.Map<StoreViewModel>(await _store.GetStore(id)));

        }
        [HttpPost]
        public async Task<ActionResult> SaveEdit(StoreViewModel store)
        {

            if (ModelState.IsValid)
            {
                //Save Successfull
                 _store.UpdateStore(_mapper.Map<Store>(store));
                await _unitOfWork.Commit();
                return RedirectToAction("index", "store");
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
             _store.DeleteStore(await _store.GetStore(id));
            await _unitOfWork.Commit();
            return RedirectToAction("index", "store");
        }
    }
}
