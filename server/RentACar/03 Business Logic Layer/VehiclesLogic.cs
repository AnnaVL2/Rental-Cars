using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpace
{
    // display, add, edit vehicles(cars)
    public class VehiclesLogic : BaseLogic
    {
        //display all cars
        public List<VehicleAndVehicleTypeDTO> GetAllVehicles()
        {
            var q = from v in DB.Vehicles
                    join vt in DB.VehicleTypes
                    on v.VehicleTypeID equals vt.VehicleTypeID
                    join b in DB.Branches on v.BranchID equals b.BranchID
                    select new VehicleAndVehicleTypeDTO
                    {
                        vehicleID = v.VehicleID,
                        vehicleTypeID = v.VehicleTypeID,
                        mileage = v.Mileage,
                        model = vt.Model,
                        manufacturer = vt.Manufacturer,
                        productionYear = vt.ProductionYear,
                        gearType = vt.GearType,
                        rentingProper = true,
                        rentingAvailibility = true,
                        registrationNumber = v.RegistrationNumber,
                        branchName = b.BranchName,
                        carImage = v.CarImage
                    };
            return q.ToList();
        }

        //display one car
        public VehicleDTO GetOneVehicle(int id)
        {
            var q = from v in DB.Vehicles
                    where v.VehicleID == id
                    select new VehicleDTO
                    {
                        vehicleTypeID = v.VehicleTypeID,
                        mileage = v.Mileage,
                        carImage = v.CarImage,
                        rentingProper = true,
                        rentingAvailibility = true,
                        registrationNumber = v.RegistrationNumber,
                        branchID = v.BranchID
                    };
             return q.SingleOrDefault();
        }

        //save image
        public void SaveImage(int id, string fileName)
        {
            Vehicle imageToAdd = DB.Vehicles.Where(c => c.VehicleID == id).SingleOrDefault();
            imageToAdd.CarImage = fileName;
            DB.SaveChanges();
        }

        //add car - admin access
        public VehicleDTO AddVehicle(VehicleDTO vehicle)
        {
            // יצירת רכב חדש בדטה בייס
            Vehicle vehicleToAdd = new Vehicle
            {
                VehicleTypeID = vehicle.vehicleTypeID,
                Mileage = vehicle.mileage,
                CarImage = vehicle.carImage,
                RentingProper = true,
                RentingAvailibility = true,
                RegistrationNumber = vehicle.registrationNumber,
                BranchID = vehicle.branchID
            };

            DB.Vehicles.Add(vehicleToAdd);
            DB.SaveChanges();
            vehicle.vehicleID = vehicleToAdd.VehicleID;
            return vehicle;
        }

        //edit cars - admin access - don't erase
        public VehicleDTO UpdateVehicle (VehicleDTO vehicle)
        {
            Vehicle vehicleToUpdate = DB.Vehicles
                .Where(v => v.VehicleID == vehicle.vehicleID).SingleOrDefault();

            if (vehicleToUpdate == null)
                return null;
            vehicleToUpdate.VehicleTypeID = vehicle.vehicleTypeID;
            vehicleToUpdate.Mileage = vehicle.mileage;
            vehicleToUpdate.RentingProper = vehicle.rentingProper;
            vehicleToUpdate.RentingAvailibility = vehicle.rentingAvailibility;
            vehicleToUpdate.RegistrationNumber = vehicle.registrationNumber;
            vehicleToUpdate.BranchID = vehicle.branchID;


            DB.SaveChanges();
            return vehicle;
        }

        //delete cars - admin access
        public void DeleteVehicle (int id)
        {
            Vehicle vehicleToDelete = DB.Vehicles
                .Where(v => v.VehicleID == id).SingleOrDefault();
            if(vehicleToDelete != null)
            {
                DB.Vehicles.Remove(vehicleToDelete);
                DB.SaveChanges();
            }
        }
    }
}
