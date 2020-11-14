import { Injectable } from '@angular/core';
import { VehicleType } from '../models/vehicle-type';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class VehicleTypesManageService {

    constructor(private httpClient: HttpClient) { }

    private allVehicleTypesUrl = "http://localhost:64284/api/vehicleTypes/all"
    public getAllVehicleTypes(): Observable<VehicleType[]> {
        return this.httpClient.get<VehicleType[]>(this.allVehicleTypesUrl);
    }

    private oneVehicleTypeUrl = "http://localhost:64284/api/vehicleTypes/vehicleTypeID"
    public getOneVehicleType(id: number): Observable<VehicleType[]> {
        return this.httpClient.get<VehicleType[]>(this.oneVehicleTypeUrl  + "/" + id);
    }

    private addVehicleTypesUrl = "http://localhost:64284/api/vehicleTypes/newVehicleType";
    public addVehicleType(vType: VehicleType): Observable<VehicleType> {
        return this.httpClient.post<VehicleType>(this.addVehicleTypesUrl, vType);
    }

    private deleteVehicleTypeUrl = "http://localhost:64284/api/vehicleTypes/delete";
    public deleteVehicleType(id: number): Observable<undefined> {
        return this.httpClient.delete<undefined>(this.deleteVehicleTypeUrl + "/" + id);
    }

    private searchVehiclesUrl = "http://localhost:64284/api/search/byDate/"
    public searchVacantVehicles(startDate: Date, endDate: Date): Observable<VehicleType[]> {
        return this.httpClient.get<VehicleType[]>(this.searchVehiclesUrl + "/" + startDate + "/" + endDate);
    }
}


