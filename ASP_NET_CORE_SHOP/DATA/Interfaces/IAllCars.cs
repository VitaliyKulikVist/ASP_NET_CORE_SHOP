using ASP_NET_CORE_SHOP.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_SHOP.DATA.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }//Дана функція дає змогу отримувати і записувати данні в модель
        IEnumerable<Car> getFavorCars { get; set; }//Дана функція поверне або засть змогу записати фейворіт(тайкращі) машини з моделі Car
        Car getObjectCar(int carId);//функція приймає лише число (а не список) і то лише ід авто
    }
}
