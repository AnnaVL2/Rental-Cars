using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpace
{
    public class RentalsLogic : BaseLogic
    {
        //display all rentals
        public List<RentalDTO> GetAllRentals()
        {
            var q = from r in DB.Rentals
                    join u in DB.Users on r.UserID equals u.UserID
                    join c in DB.Vehicles on r.VehicleID equals c.VehicleID
                    select new RentalDTO
                    {
                        rentalCode = r.RentalCode,
                        pickupDate = r.PickupDate,
                        estimatedReturnDate = r.EstimatedReturnDate,
                        actualReturnDate = r.ActualReturnDate,
                        userName = u.UserName,
                        registrationNumber = c.RegistrationNumber,
                        vehicleID = r.VehicleID,
                        userID = r.UserID
                    };
            return q.ToList();
        }

        // add new rental - user access:
        public RentalDTO AddRental(RentalDTO rental)
        {
            Rental rentalToAdd = new Rental
            {
                PickupDate = rental.pickupDate,
                EstimatedReturnDate = rental.estimatedReturnDate,
                ActualReturnDate = rental.actualReturnDate,
                UserID = rental.userID,
                VehicleID = rental.vehicleID,
                Manufacturer = rental.manufacturer,
                Model = rental.model
            };

            DB.Rentals.Add(rentalToAdd);
            DB.SaveChanges();
            rental.rentalCode = rentalToAdd.RentalCode;
            return rental;
        }

        // modify rental - manager access
        public RentalDTO UpdateRental(RentalDTO rental)
        {
            Rental rentalToUpdate = DB.Rentals
                .Where(r => r.RentalCode == r.RentalCode).SingleOrDefault();

            if (rentalToUpdate == null)
                return null;

            rentalToUpdate.PickupDate = rental.pickupDate;
            rentalToUpdate.EstimatedReturnDate = rental.estimatedReturnDate;
            rentalToUpdate.ActualReturnDate = rental.actualReturnDate;
            rentalToUpdate.UserID = rental.userID;
            rentalToUpdate.VehicleID = rental.vehicleID;

            DB.SaveChanges();
            return rental;
        }

        // delete rental - manager access
        public void DeleteRental(int id)
        {
            Rental rentalToDelete = DB.Rentals
                .Where(r => r.RentalCode == id).SingleOrDefault();
            if (rentalToDelete != null)
            {
                DB.Rentals.Remove(rentalToDelete);
                DB.SaveChanges();
            }
        }
    }
}
