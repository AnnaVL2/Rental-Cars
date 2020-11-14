import { Component, OnInit } from '@angular/core';
import { VehicleTypesManageService } from 'src/app/services/vehicle-types-manage.service';
import { VehicleType } from 'src/app/models/vehicle-type';


@Component({
    selector: 'app-vehicle-types-manage',
    templateUrl: './vehicle-types-manage.component.html',
    styleUrls: ['./vehicle-types-manage.component.css']
})
export class VehicleTypesManageComponent implements OnInit {

    public allVehicleTypes: VehicleType[];
    public filteredVehicleTypes: VehicleType[];

    public ok: boolean = true;
    public oneVehicleType = new VehicleType();
    public startDate: Date;
    public endDate: Date;
    public vehicle = new VehicleType();

    public constructor(private vehicleTypesManageSevice: VehicleTypesManageService) { }

    public ngOnInit(): void {
        this.vehicleTypesManageSevice.getAllVehicleTypes()
            .subscribe(
                vehicleTypes => this.allVehicleTypes = vehicleTypes,
                err => {
                    alert(err.message);
                    this.ok = false;
                },
                () => console.log("Done")
            );
    }

    public deleteVehicleType(): void {
        this.vehicleTypesManageSevice.deleteVehicleType(this.oneVehicleType.vehicleTypeID)
            .subscribe(() => alert("Vehicle Type Delete. id: " + this.oneVehicleType.vehicleTypeID),
                err => alert(err.message)
            );
    }
}
