using System;

namespace MySpace
{
    public class VehicleDTO
    {
        public int vehicleID { get; set; }
        public int vehicleTypeID { get; set; }
        public int mileage { get; set; }
        public Boolean rentingProper { get; set; }
        public Boolean rentingAvailibility { get; set; }
        public int registrationNumber { get; set; }
        public int branchID { get; set; }
        public string carImage { get; set; }

        //display
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string branchName { get; set; }

    }


}
