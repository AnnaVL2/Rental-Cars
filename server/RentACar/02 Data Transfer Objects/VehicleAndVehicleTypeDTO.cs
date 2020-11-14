using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpace
{
    public class VehicleAndVehicleTypeDTO
    {
        public int vehicleID { get; set; }
        public int vehicleTypeID { get; set; }
        public int mileage { get; set; }
        public string carImage { get; set; }
        public bool rentingProper { get; set; }
        public bool rentingAvailibility { get; set; }
        public int registrationNumber { get; set; }
        public string branch { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public DateTime productionYear { get; set; }
        public string gearType { get; set; }
        public string branchName { get; set; }
    }
}
