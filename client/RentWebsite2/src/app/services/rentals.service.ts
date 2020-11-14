import { Injectable } from '@angular/core';
import { Rental } from '../models/rental';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";


@Injectable({
    providedIn: 'root'
})
export class RentalsService {

    public constructor(private httpClient: HttpClient) { }
    
    // display all rentals
    private allRentalsUrl = "http://localhost:64284/api/rentals/all"
    public getAllRentals(): Observable<Rental[]> {
        return this.httpClient.get<Rental[]>(this.allRentalsUrl);
    }

    //add new rental
    private addRentalUrl = "http://localhost:64284/api/rentals/newRental";
    public addRental(rental: Rental): Observable<Rental> {
        return this.httpClient.post<Rental>(this.addRentalUrl, rental);
    }

    //delete rental
    private deleteRentalUrl = "http://localhost:64284/api/admin/deleteRental";
    public deleteRental(id: number): Observable<undefined> {
        return this.httpClient.delete<undefined>(this.deleteRentalUrl + "/" + id);
    }

    private editRentalUrl = "http://localhost:64284/api/rentals";
    public updateRental(id: number): Observable<Rental> {
        return this.httpClient.put<Rental>(this.editRentalUrl, id);
    }
}
