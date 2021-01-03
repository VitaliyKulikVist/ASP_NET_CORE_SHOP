using ASP_NET_CORE_SHOP.DATA.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ASP_NET_CORE_SHOP.Controllers
{
	public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController (IAllCars allCars, ICarsCategory carsCategory)
        {
            _allCars = allCars ?? throw new ArgumentNullException(nameof(allCars));
            _allCategories = carsCategory ?? throw new ArgumentNullException(nameof(carsCategory));
        }

        public ViewResult List()
        {
            ViewBag.Cars = "Щось нове";

            return View(_allCars.GetAllCars());
        }
    }
}
