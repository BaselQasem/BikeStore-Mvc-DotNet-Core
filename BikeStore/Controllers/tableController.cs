using AutoMapper;
using BikeStore.Models;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    public class tableController : Controller
    {

        private readonly IBrand _brand;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public tableController(IBrand brand, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _brand = brand;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(int pageNumber, int pagesCount, int Sorting)
        {

            var ListbrandViewModel = _mapper.Map<IEnumerable<BrandViewModel>>(await _brand.GetBrands());
            var ordList = Sorting == 1 ? ListbrandViewModel.OrderByDescending(o => o.BrandName) : ListbrandViewModel.OrderBy(o => o.BrandName);

            ViewBag.sort = Sorting;
            ViewBag.PN = pageNumber;
            ViewBag.PagesCount = ((ordList.Count() - 1) / 5) + 1;

            return View(ordList.Skip((pageNumber - 1) * 5).Take(5));
        }
    }
}
