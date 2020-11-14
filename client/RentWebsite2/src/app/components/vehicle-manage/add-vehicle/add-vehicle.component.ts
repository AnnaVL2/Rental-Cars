import { Component, OnInit } from '@angular/core';
import { Vehicle } from 'src/app/models/vehicle';
import { VehiclesService } from 'src/app/services/vehicles.service';



@Component({
  selector: 'app-add-vehicle',
  templateUrl: './add-vehicle.component.html',
  styleUrls: ['./add-vehicle.component.css']
})
export class AddVehicleComponent implements OnInit {

  public vehicle = new Vehicle();
  public ok: boolean = false;


  public constructor(private vehiclesService : VehiclesService) { }

  ngOnInit() {
  }

  public addVehicle():void{
      this.vehiclesService.addVehicle(this.vehicle).subscribe(
          vehicle => alert("done" + vehicle.vehicleID),
          err=>alert(err.message));}
  }



