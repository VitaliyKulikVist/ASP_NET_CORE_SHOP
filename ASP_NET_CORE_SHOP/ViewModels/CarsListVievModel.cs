using ASP_NET_CORE_SHOP.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_SHOP.ViewModels
{
    public class CarsListVievModel
    {
        public IEnumerable<Car> allCars { get; set; }
        public string carrCategory { get; set; }
    }
}
