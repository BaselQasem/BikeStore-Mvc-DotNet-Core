using AutoMapper;
using BikeStore.Classes;
using BikeStore.Models;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer _customer;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        int pageSize=10;
        public CustomerController(ICustomer customer, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _customer = customer;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CustomersList(TableQuery customerFiltered)
        {

            customerFiltered.PageSize = pageSize;
            customerFiltered.RowNumberStart = ((customerFiltered.PageNumber - 1) * pageSize);

            var CustomersWithPageCount = await _customer.GetCustomerFilter(customerFiltered);
            var ListcustomerViewModel = _mapper.Map<List<CustomerViewModel>>(CustomersWithPageCount.Item1);
            customerFiltered.PagesCount = CustomersWithPageCount.Item2 ;
            customerFiltered.PageSize = 10;
            ViewBag.Filtered = customerFiltered;

            return PartialView("_customer", ListcustomerViewModel);
        }
        public ActionResult Create()
        {
            return PartialView("_Create", new CustomerViewModel());
        }


        [HttpPost]
        public async Task<ActionResult> Create(CustomerViewModel customer)
        {

            if (ModelState.IsValid)
            {
                //Add Successfull
                await _customer.InserCustomer(_mapper.Map<Customer>(customer));
                await _unitOfWork.Commit();
            }
            else
            {
                //failed to Add
                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Unknown error");
                return View("Index");
            }
            return RedirectToAction("index", "customer");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return PartialView("_Edit", _mapper.Map<CustomerViewModel>(await _customer.GetCustomer(id)));

        }
        [HttpPost]
        public async Task<ActionResult> SaveEdit(CustomerViewModel customer)
        {

            if (ModelState.IsValid)
            {
                //Save Successfull
                 _customer.UpdateCustomer(_mapper.Map<Customer>(customer));
                await _unitOfWork.Commit();
                return RedirectToAction("index", "customer");

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
             _customer.DeleteCustomer(await _customer.GetCustomer(id));
            await _unitOfWork.Commit();
            return RedirectToAction("index", "customer");
        }
    }
}
