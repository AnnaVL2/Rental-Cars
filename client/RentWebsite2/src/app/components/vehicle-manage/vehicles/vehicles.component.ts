import { Component, OnInit } from '@angular/core';
import { Vehicle } from 'src/app/models/vehicle';
import { VehiclesService } from 'src/app/services/vehicles.service';


@Component({
    selector: 'app-vehicles',
    templateUrl: './vehicles.component.html',
    styleUrls: ['./vehicles.component.css']
})
export class VehiclesComponent implements OnInit {

    public allVehicles: Vehicle[];
    public filteredVehicles: Vehicle[];
    public ok: boolean = true;
    public vehicle = new Vehicle();
    // public rental = new Rental();


    public constructor(private vehiclesService: VehiclesService) { }
    public ngOnInit(): void {

        this.vehiclesService.getAllVehicles()
            .subscribe(
                vehicles => this.allVehicles = vehicles,
                err => {
                    alert(err.message);
                    this.ok = false;
                },
                () => console.log("Done.")
            );
    }
    
}
