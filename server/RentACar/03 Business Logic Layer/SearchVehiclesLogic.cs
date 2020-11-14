using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpace
{

    public class SearchVehiclesLogic : BaseLogic
    {
        public List<SearchVehicleDTO> searchVehicles(DateTime pickupDate, DateTime estimatedReturnDate)
        {
            var q = from c in DB.GetAvailableCars2(pickupDate, estimatedReturnDate)
                    select new SearchVehicleDTO
                    {
                        gearType = c.GearType,
                        manufacturer = c.Manufacturer,
                        productionYear = c.ProductionYear,
                        model = c.Model,
                        vehicleID = c.VehicleID,
                        carImage = c.CarImage,
                        dailyFee = c.DailyFee,
                        overdueFee = c.OverdueFee,
                        branchID = c.BranchID

                    };
            return q.ToList();
        }
    }
}
