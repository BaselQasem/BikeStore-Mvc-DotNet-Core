using AutoMapper;
using BikeStore.Classes;
using BikeStore.Models;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{

    public class OrderController : Controller
    {
        private readonly IOrder _order;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomer _customer;
        private readonly IStore _store;
        private readonly IProduct _prodcut;
        private readonly IStaff _staff;
        private readonly IOrderItem _orderItem;
        readonly int pageSize = 10;


        public OrderController(IUnitOfWork unitOfWork, IOrder order, IMapper mapper, ICustomer customer
            ,IStore store, IStaff staff, IProduct product, IOrderItem orderItem)
        {
            _unitOfWork = unitOfWork;
            _order = order;
            _mapper = mapper;
            _customer = customer;
            _store = store;
            _staff = staff;
            _prodcut = product;
            _orderItem = orderItem;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> OrdersList(TableQuery orderFiltered)
        {

            orderFiltered.PageSize = pageSize;
            orderFiltered.RowNumberStart = ((orderFiltered.PageNumber - 1) * pageSize);

            var OrdersWithPageCount = await _order.getOrderFiltered(orderFiltered);
            var ListOrderViewModel = _mapper.Map<List<OrderViewModel>>(OrdersWithPageCount.Item1);


            orderFiltered.PagesCount = OrdersWithPageCount.Item2;
            orderFiltered.PageSize = 10;
            ViewBag.Filtered = orderFiltered;


            return PartialView("_order", ListOrderViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.CustomerList = _mapper.Map<List<CustomerViewModel>>(await _customer.GetCustomers());
            ViewBag.StoreList = _mapper.Map<List<StoreViewModel>>( await _store.GetStores());
            ViewBag.StaffList = _mapper.Map<List<StaffViewModel>>( await _staff.GetStaffs());
            ViewData["ProductList"] = _mapper.Map<List<ProductViewModel>>( await _prodcut.GetProducts());
            return PartialView("_Create");

        }

        [HttpPost]
        public async Task<ActionResult> Create(OrderViewModel order)
        {

            if (ModelState.IsValid)
            {
                //Add Successfull
                await _order.InserOrder(_mapper.Map<Order>(order));
                await _unitOfWork.Commit();
            }
            else
            {
                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Unknown error");
                return View("Index");
            }
           

          return RedirectToAction("index", "order");
        }


        //Return product price when select from select list
        [HttpGet]
        public async Task<decimal> ProductPrice(int productId)
        {
            var p = _mapper.Map<ProductViewModel>(await _prodcut.GetProduct(productId));
            return p.ListPrice;
        }
        public async Task<IActionResult> Delete(int id)
        {
             _order.DeleteOrder(await _order.GetOrder(id));
             _orderItem.RemoveRange((await _orderItem.GetOrderItemByOrderId(id)));
            await _unitOfWork.Commit();
            return RedirectToAction("index", "customer");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            OrderViewModel orderViewModel = _mapper.Map<OrderViewModel>((await _order.getOrderByID(id)));
            orderViewModel.OrderItems = _mapper.Map<List<OrderItemViewModel>>(await _orderItem.getOrderItemById(id));


            ViewBag.CustomerList = _mapper.Map<List<CustomerViewModel>>(await _customer.GetCustomers());
            ViewBag.StoreList = _mapper.Map<List<StoreViewModel>>(await _store.GetStores());
            ViewBag.StaffList = _mapper.Map<List<StaffViewModel>>(await _staff.GetStaffs());
            ViewData["ProductList"] = _mapper.Map<List<ProductViewModel>>(await _prodcut.GetProducts());

            return PartialView("_Edit", orderViewModel);

        }

        [HttpPost]
        public async Task<ActionResult> SaveEdit(OrderViewModel order)
        {
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                //Save Successfull
                 _order.UpdateOrder(_mapper.Map<Order>(order));
                await _unitOfWork.Commit();
                return RedirectToAction("index", "order");

            }
            else
            {
                //failed To Save
                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Unknown error");
                return View("Index");

            }

        }
    }
}
