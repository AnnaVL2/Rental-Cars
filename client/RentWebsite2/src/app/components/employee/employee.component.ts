import { Component, OnInit } from '@angular/core';
import { Vehicle } from 'src/app/models/vehicle';
import { VehiclesService } from 'src/app/services/vehicles.service';
import { Rental } from 'src/app/models/rental';
import { RentalsService } from 'src/app/services/rentals.service';
import { VehicleType } from 'src/app/models/vehicle-type';
import { VehicleTypesManageService } from 'src/app/services/vehicle-types-manage.service';

@Component({
    selector: 'app-employee',
    templateUrl: './employee.component.html',
    styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

    constructor(private vehicleTypeService: VehicleTypesManageService,
        private rentalService: RentalsService, private vehicleService: VehiclesService) { }

    public rental = new Rental();
    public registrationNumber: number;
    // public registrationNumberArr = ["659874", "235689", "124578", "987654"];
    public allRentals: Rental[];
    public allVehicles: Vehicle[];
    public vehicle = new Vehicle();
    public date = new Date();
    public allVehicleTypes: VehicleType[];
    public vehicleType = new VehicleType();
    public ok: boolean = false;

    public filteredVehicles: Vehicle[];

    public ngOnInit(): void {

        //rental array
        this.rentalService.getAllRentals().subscribe(
            r => this.allRentals = r,
            err => alert(err.message)
        );
        //vehicles array
        this.vehicleService.getAllVehicles().subscribe(
            v => this.allVehicles = v,
            err => alert(err.message)
        );
        //vehicle types array
        this.vehicleTypeService.getAllVehicleTypes().subscribe(
            vt => this.allVehicleTypes = vt,
            err => alert(err.message)
        );
    }

    public onSearchRegistrationNumber(registrationNumber: number): void {
        this.filteredVehicles = this.allVehicles.filter(v =>
            v.registrationNumber == registrationNumber);
    }

    //rental search
    public findOneRental(): void {
        this.vehicle = this.allVehicles.find(v => v.registrationNumber == this.registrationNumber);
        if (!this.vehicle) {
            alert("מספר הרכב לא קיים");
        }
        else {
            this.rental = this.allRentals.find(r => r.vehicleID == this.vehicle.vehicleID);
            if (!this.rental || (this.rental.pickupDate < this.date && this.rental.actualReturnDate == null)) {
                alert("אין הזמנה פתוחה לרכב זה");
            }
            else {
                this.rental.actualReturnDate = this.date;
                this.vehicleType = this.allVehicleTypes.find(vt => this.vehicle.vehicleTypeID == vt.vehicleTypeID);//לצורך חישוב העלויות
                this.ok = true;
            }
        }
    }


    //החזרה- עדכון תאריך החזרה בפועל
    // public returnCar() {
    //     this.rentalService.updateRental(this.rental).subscribe(
    //         r => {
    //             this.rental = r;
    //             alert("השכרה נסגרה בהצלחה");
    //             window.location.reload();
    //         },
    //         err => alert(err.message)
    //     );
    // }


    
}
