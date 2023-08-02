using AutoMapper;
using BikeStore.Classes;
using BikeStore.Models;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace BikeStore.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProduct _product;
        private readonly IStore _store;
        private readonly IStock _stock;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategory _category;
        private readonly IBrand _brand;
        readonly int pageSize = 10;
        public ProductController(IProduct product, IMapper mapper, IUnitOfWork unitOfWork,
            ICategory category, IBrand brand, IStore store, IStock stock)
        {
            _product = product;
            _store = store;
            _stock = stock;
            _category = category;
            _brand = brand;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.CategoryList = await getCategoryList();
            return View();
        }

        public async Task<ActionResult> ProductsList(TableQuery productFiltered)
        {


            productFiltered.PageSize = pageSize;
            productFiltered.RowNumberStart = ((productFiltered.PageNumber-1) * pageSize);
            
            var ProductsWithPageCount = await _product.GetProductFilter(productFiltered);
            var ListproductViewModel = _mapper.Map<List<ProductViewModel>>(ProductsWithPageCount.Item1);
         

            productFiltered.PagesCount = ProductsWithPageCount.Item2;
            productFiltered.PageSize = 10;
            ViewBag.Filtered = productFiltered;

            return PartialView("_product", ListproductViewModel);
        }
        public async Task<ActionResult> Create()
        {

            ViewBag.CategoryList = (await getCategoryList()).ToList();
            ViewBag.BrandList = _mapper.Map<List<BrandViewModel>>(await _brand.GetBrands());

            return PartialView("_Create", new ProductViewModel());
        }


        [HttpPost]
        public async Task<ActionResult> Create(ProductViewModel product)
        {

            if (ModelState.IsValid)
            {
                //Add Successfull
                var ProductItem = _mapper.Map<Product>(product);
                await _product.InserProduct(ProductItem);
                await _unitOfWork.Commit();

                /*retun product id after commit and use to insert to sock table with 0 initial value for each store for this item*/
                var stores = await _store.GetStores();
                List<Stock> stocks = new List<Stock>();
                foreach (var elm in stores)
                {
                    stocks.Add(new Stock() { ProductId = ProductItem.ProductId, StoreId = elm.StoreId, Quantity = 0 });

                }
                await _stock.AddRange(stocks);
                await _unitOfWork.Commit();
            }
            else
            {
                //failed to Add
                ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Unknown error");
                return View("Index");
            }
            return RedirectToAction("index", "product");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var productViewModel = _mapper.Map<ProductViewModel>((await _product.GetProductById(id)));
            ViewBag.CategoryList = (await getCategoryList()).ToList(); 
            ViewBag.BrandList = _mapper.Map<List<BrandViewModel>>(await _brand.GetBrands());

            return PartialView("_Edit", productViewModel);

        }
        [HttpPost]
        public async Task<ActionResult> SaveEdit(ProductViewModel product)
        {
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                //Save Successfull
               
                 _product.UpdateProduct(_mapper.Map<Product>(product));
                await _unitOfWork.Commit();
                return RedirectToAction("index", "product");

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
             _product.DeleteProduct( await _product.GetProduct(id));
             _stock.RemoveRange((await _stock.GetStockByProductId(id)).ToList());
            await _unitOfWork.Commit();
            return RedirectToAction("index", "product");
        }

        public async Task<List<CategoryViewModel>> getCategoryList()
        {
            return _mapper.Map<List<CategoryViewModel>>(await _category.GetCategories());

        }

    }
}
