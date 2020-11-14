using System.Collections.Generic;
using System.Linq;

namespace MySpace
{
    public class VehicleTypesLogic : BaseLogic
    {
        //display all cars
        public List<VehicleTypeDTO> GetAllVehicleTypes()
        {
            var q = from vTypes in DB.VehicleTypes
                    select new VehicleTypeDTO
                    {
                        vehicleTypeID = vTypes.VehicleTypeID,
                        manufacturer = vTypes.Manufacturer,
                        model = vTypes.Model,
                        dailyFee = vTypes.DailyFee,
                        overdueFee = vTypes.OverdueFee,
                        productionYear = vTypes.ProductionYear,
                        gearType = vTypes.GearType
                    };
            return q.ToList();
        }

        public VehicleTypeDTO GetOneVehicleType(int vehicleTypeID)
        {
            var q = from vType in DB.VehicleTypes
                    where vType.VehicleTypeID == vehicleTypeID
                    select new VehicleTypeDTO
                    {
                        vehicleTypeID = vType.VehicleTypeID,
                        gearType = vType.GearType,
                        productionYear = vType.ProductionYear,
                        manufacturer = vType.Manufacturer,
                        model = vType.Model
                    };
            return q.SingleOrDefault();
        }

        // functions for manager:
        public VehicleTypeDTO AddVehicleType (VehicleTypeDTO vType)
        {
            VehicleType vehicleToAdd = new VehicleType
            {
                VehicleTypeID = vType.vehicleTypeID,
                Manufacturer = vType.manufacturer,
                Model = vType.model,
                DailyFee = (int)vType.dailyFee,
                OverdueFee = (int)vType.overdueFee,
                GearType = vType.gearType,
                ProductionYear = vType.productionYear

            };

            DB.VehicleTypes.Add(vehicleToAdd);
            DB.SaveChanges();

            // vType עדכון קוד סוג הרכב שמסד הנתונים יצר במשתנה
            vType.vehicleTypeID = vehicleToAdd.VehicleTypeID;

            // יוכל להחזיר אותו ללקוח Web API-כך שפרויקט ה vType החזרת המשתנה
            return vType;
        }

        public VehicleTypeDTO UpdateVehicleType (VehicleTypeDTO vType)
        {
            VehicleType vehicleTypeToUpdate = DB.VehicleTypes
                .Where(v => v.VehicleTypeID == v.VehicleTypeID).SingleOrDefault();

            if (vehicleTypeToUpdate == null)
                return null;
            vehicleTypeToUpdate.Manufacturer = vType.manufacturer;
            vehicleTypeToUpdate.Model = vType.model;
            vehicleTypeToUpdate.DailyFee = (int) vType.dailyFee;
            vehicleTypeToUpdate.OverdueFee = (int) vType.overdueFee;
            vehicleTypeToUpdate.GearType = vType.gearType;
            vehicleTypeToUpdate.ProductionYear = vType.productionYear;
            DB.SaveChanges();
            return vType;
        }

        public void DeleteVehicleType (int id)
        {
            VehicleType vehicleTypeToDelete = DB.VehicleTypes
                .Where(v => v.VehicleTypeID == id).SingleOrDefault();
            if (vehicleTypeToDelete != null)
            {
                DB.VehicleTypes.Remove(vehicleTypeToDelete);
                DB.SaveChanges();
            }
        }
    }
    
}
