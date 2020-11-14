import { Injectable } from '@angular/core';
import { SearchCar } from '../models/search-car';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class SearchCarService {

    constructor(private httpClient: HttpClient) { }
    
    //search by dates
    private searchVehiclesUrl = "http://localhost:64284/api/rentals/byDate"
    public searchVehicles(pickupDate: Date, estimatedReturnDate: Date): Observable<SearchCar[]> {
        return this.httpClient.get<SearchCar[]>(this.searchVehiclesUrl + "/" + pickupDate + "/" + estimatedReturnDate);
    }

    // private searchCarsUrl = "http://localhost:64284/api/vehicleTypes/all"
    // public getAllCars(): Observable<SearchCar[]> {
    //     return this.httpClient.get<SearchCar[]>(this.searchCarsUrl);
    // }



}
