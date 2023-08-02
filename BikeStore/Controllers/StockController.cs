using AutoMapper;
using BikeStore.Classes;
using BikeStore.Models;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    public class StockController : Controller
    {

        private readonly IStock _stock;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProduct _product;
        private readonly IStore _store;
        int pageSize = 10;
        public StockController(IStock stock, IMapper mapper, IUnitOfWork unitOfWork, IProduct product, IStore store)
        {
            _stock = stock;
            _product = product;
            _store = store;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> StocksList(TableQuery stockFiltered)
        {

            stockFiltered.PageSize = pageSize;
            stockFiltered.RowNumberStart = ((stockFiltered.PageNumber - 1) * pageSize);

            var StocksWithPageCount = await _stock.geStockFiltered(stockFiltered);
            var ListStockViewModel = _mapper.Map<List<StockViewModel>>(StocksWithPageCount.Item1);


            stockFiltered.PagesCount = StocksWithPageCount.Item2;
            stockFiltered.PageSize = 10;
            ViewBag.Filtered = stockFiltered;
            return PartialView("_stock", ListStockViewModel);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int store_id ,int product_id)
        {
            var stockViewModel = _mapper.Map<StockViewModel>((await _stock.getStockByID(store_id, product_id)));

            ViewBag.ProductList = _mapper.Map<List<ProductViewModel>>(await _product.GetProducts());
            ViewBag.StoreList = _mapper.Map<List<StoreViewModel>>(await _store.GetStores());

            return PartialView("_Edit", stockViewModel);

        }
        [HttpPost]
        public async Task<ActionResult> SaveEdit(StockViewModel stock)
        {
            // var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                    //Save Successfull
                     _stock.UpdateStock(_mapper.Map<Stock>(stock));
                    await _unitOfWork.Commit();
                    return RedirectToAction("index", "stock");
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
