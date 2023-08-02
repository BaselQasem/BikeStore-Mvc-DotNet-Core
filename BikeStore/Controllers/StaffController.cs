using AutoMapper;
using BikeStore.Classes;
using BikeStore.Models;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaff _staff;
        private readonly IStore _store;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        int pageSize = 10;
        public StaffController(IStaff staff, IMapper mapper, IUnitOfWork unitOfWork,IStore store)
        {
            _staff = staff;
            _mapper = mapper;
            _store= store;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> StaffsList(TableQuery StaffFiltered)
        {

            StaffFiltered.PageSize = pageSize;
            StaffFiltered.RowNumberStart = ((StaffFiltered.PageNumber - 1) * pageSize);

            var StaffsWithPageCount = await _staff.GetStaffFilter(StaffFiltered);
            var ListStaffViewModel = _mapper.Map<List<StaffViewModel>>(StaffsWithPageCount.Item1);

            StaffFiltered.PagesCount = StaffsWithPageCount.Item2;
            StaffFiltered.PageSize = 10;
            ViewBag.Filtered = StaffFiltered;
            
            return PartialView("_staff", ListStaffViewModel);
        }
        public async Task<ActionResult> Create()
        {

            ViewBag.StoreList =  _mapper.Map<List<StoreViewModel>>(await _store.GetStores());
            ViewBag.ManagerList = _mapper.Map<List<StaffViewModel>>(await _staff.GetStaffs());

            return PartialView("_Create", new StaffViewModel());
        }


        [HttpPost]
        public async Task<ActionResult> Create(StaffViewModel staff)
        {
            if (ModelState.IsValid)
            {
                //Add Successfull
                await _staff.InserStaff(_mapper.Map<Staff>(staff));
                await _unitOfWork.Commit();
            }
            else
            {
                //failed to Add
                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Unknown error");
                return View("Index");
            }
            return RedirectToAction("index", "staff");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            
            ViewBag.StoreList = _mapper.Map<List<StoreViewModel>>(await _store.GetStores());
            ViewBag.ManagerList = _mapper.Map<List<StaffViewModel>>(await _staff.GetStaffs());

            return PartialView("_Edit", _mapper.Map<StaffViewModel>(await _staff.GetStaffById(id)));

        }
        [HttpPost]
        public async Task<ActionResult> SaveEdit(StaffViewModel staff)
        {

            if (ModelState.IsValid)
            {
                //Save Successfull
                 _staff.UpdateStaff(_mapper.Map<Staff>(staff));
                await _unitOfWork.Commit();
                return RedirectToAction("index", "staff");

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
             _staff.DeleteStaff(await _staff.GetStaff(id));
            await _unitOfWork.Commit();
            return RedirectToAction("index", "staff");
        }
    }
}
