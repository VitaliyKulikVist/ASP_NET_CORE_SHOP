using ASP_NET_CORE_SHOP.DATA.Models;
using System.Collections.Generic;

namespace ASP_NET_CORE_SHOP.DATA.Interfaces
{
	public interface IAllCars
    {
        IEnumerable<Car> GetAllCars();
        IEnumerable<Car> GetVafouriteCars();
        Car GetCarById(int carId);
    }
}
