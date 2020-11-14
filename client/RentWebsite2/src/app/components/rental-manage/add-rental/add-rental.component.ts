import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Rental } from 'src/app/models/rental';
import { RentalsService } from 'src/app/services/rentals.service';
import { User } from 'src/app/models/user';
import { UsersService } from 'src/app/services/users.services';
import { Vehicle } from 'src/app/models/vehicle';
import { VehicleType } from 'src/app/models/vehicle-type';

import { VehicleTypesManageService } from 'src/app/services/vehicle-types-manage.service';
import { VehiclesService } from 'src/app/services/vehicles.service';


@Component({
    selector: 'app-add-rental',
    templateUrl: './add-rental.component.html',
    styleUrls: ['./add-rental.component.css']
})
export class AddRentalComponent {

    public rental = new Rental();
    public allVehicles: Vehicle[];
    public oneVehicleType: VehicleType[];
    public allVehicleTypes: VehicleType[];
    public allUsers: User[];
    public id: number;


    public constructor(private rentalsService: RentalsService,
        private vehicleService: VehiclesService,
        private userService: UsersService,
        private vehicleTypesManageService: VehicleTypesManageService,
        private router: Router) { }

    ngOnInit() {// vehicles to choose
        this.vehicleService.getAllVehicles().subscribe(
            v => this.allVehicles = v,
            err => console.log(err.message)
        );

        // users to choose
        this.userService.getAllUsers().subscribe(
            u => this.allUsers = u,
            err => console.log(err.message)
        );

        // vehicle type to choose
        this.vehicleTypesManageService.getAllVehicleTypes().subscribe(
            vt => this.allVehicleTypes = vt,
            err => console.log(err.message)
        );

        // one vehicle type to show
        this.vehicleTypesManageService.getOneVehicleType(this.id).subscribe(
            vt1 => this.oneVehicleType = vt1,
            err => console.log(err.message)
        );
    }

    public addRental(): void {
        this.rentalsService.addRental(this.rental).subscribe(
            rental => {
                alert("done" + rental.rentalCode);
                this.router.navigate(["/home"])
            },
            err => alert(err.message));
    }

}
