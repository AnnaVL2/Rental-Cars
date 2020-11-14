import { Component, OnInit } from '@angular/core';
import { VehicleType } from 'src/app/models/vehicle-type';
import { VehicleTypesManageService } from 'src/app/services/vehicle-types-manage.service';

@Component({
  selector: 'app-add-vehicle-type',
  templateUrl: './add-vehicle-type.component.html',
  styleUrls: ['./add-vehicle-type.component.css']
})
export class AddVehicleTypeComponent implements OnInit {

  public vehicleType = new VehicleType();

  public constructor(private vehicleTypesService: VehicleTypesManageService) { }

  ngOnInit() {
  }

  public addVehicleType():void{
    this.vehicleTypesService
    .addVehicleType(this.vehicleType)
    .subscribe(
        vehicle =>alert("done" + vehicle.vehicleTypeID),
        err=>alert(err.message));}
}
