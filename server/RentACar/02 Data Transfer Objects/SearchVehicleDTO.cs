using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpace
{
    public class SearchVehicleDTO
    {
        public int? searchID { get; set; }
        public string gearType { get; set; }
        public string manufacturer { get; set; }
        public DateTime? productionYear { get; set; }
        public string model { get; set; }
        public DateTime? pickupDate { get; set; }
        public DateTime? estimatedReturnDate { get; set; }
        public decimal dailyFee { get; set; }
        public decimal overdueFee { get; set; }
        public int vehicleID { get; set; }
        public string carImage { get; set; }
        public int branchID { get; set; }
        public int vehicleTypeID { get; set; }
    }
}
