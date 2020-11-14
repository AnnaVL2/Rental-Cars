import { Injectable } from '@angular/core';
import { Vehicle } from '../models/vehicle';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})

export class VehiclesService {

    public constructor(private httpClient: HttpClient) { }

    private allVehiclesUrl = "http://localhost:64284/api/vehicles/all"
    public getAllVehicles(): Observable<Vehicle[]> {
        return this.httpClient.get<Vehicle[]>(this.allVehiclesUrl);
    }

    //manager authorized area

    // add a car
    private addVehicleUrl = "http://localhost:64284/api/vehicles/newVehicle";
    public addVehicle(car: Vehicle): Observable<Vehicle> {
        return this.httpClient.post<Vehicle>(this.addVehicleUrl, car);
    }

    private deleteVehicleUrl = "http://localhost:64284/api/vehicles/newVehicle";
    public deleteCar(id: number): Observable<undefined> {
        return this.httpClient.delete<undefined>(this.deleteVehicleUrl + "/" + id);
    }
}
