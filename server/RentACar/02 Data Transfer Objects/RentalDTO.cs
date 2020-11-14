using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpace
{
    public class RentalDTO
    {
        public int rentalCode { get; set; }
        public DateTime pickupDate { get; set; }
        public DateTime estimatedReturnDate { get; set; }
        public DateTime? actualReturnDate { get; set; }
        public int userID { get; set; }
        public int vehicleID { get; set; }

        public string manufacturer { get; set; }
        public string model { get; set; }
        public string userName { get; set; }
        public int registrationNumber { get; set; }
        public string image { get; set; }
    }
}
