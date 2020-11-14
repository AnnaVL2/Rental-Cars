using System;

namespace MySpace
{
    public class VehicleTypeDTO
    {
        public int vehicleTypeID { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public decimal dailyFee { get; set; }
        public decimal overdueFee { get; set; }
        public string gearType { get; set; }
        public DateTime productionYear { get; set; }

    }
}
