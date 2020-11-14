using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpace
{
    public class SearchVehicleLogic : BaseLogic
    {
        public List<SearchVehicleDTO> searchVehicles(DateTime pickupDate, DateTime estimatedReturnDate)
        {
            var q = from c in DB.GetAvailabeCar(pickupDate, estimatedReturnDate)
                    select new SearchVehicleDTO
                    {
                        gearType = c.GearType,
                        productionYear = c.ProductionYear,
                        manufacturer = c.Manufacturer,
                        model = c.Model,
                        vehicleID = c.VehicleID
                    };
            return q.ToList();
        }
    }


    [HttpGet]
    [Route("byDate/{start}/{end}")]
    public HttpResponseMessage CarByDate(DateTime start, DateTime end)
    {
        try
        {
            List<SearchCarDTO> searchCars = searchLogic.searchCars(start, end);
            return Request.CreateResponse(HttpStatusCode.OK, searchCars);
        }
        catch (Exception ex)
        {
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
