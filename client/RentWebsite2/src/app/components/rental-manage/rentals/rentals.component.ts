import { Component, OnInit } from '@angular/core';
import { RentalsService } from 'src/app/services/rentals.service';
import { Rental } from 'src/app/models/rental';
import { UsersService } from 'src/app/services/users.services';
import { HttpClient } from "@angular/common/http";


@Component({
    selector: 'app-rentals',
    templateUrl: './rentals.component.html',
    styleUrls: ['./rentals.component.css']
})
export class RentalsComponent implements OnInit {

    public allRentals: Rental[];
    public ok: boolean = true;
    public rental = new Rental();



    public constructor(private rentalsService: RentalsService,
        private userService: UsersService) { }

    public ngOnInit(): void {
        this.rentalsService.getAllRentals()
            .subscribe(
                rentals => this.allRentals = rentals,
                err => {
                    alert(err.message);
                    this.ok = false;
                },
                () => console.log("Done.")
            );
    }

    public deleteRental(id: number): void {
        this.rentalsService.deleteRental(id)
            .subscribe(() => alert("rental delete. id: " + id),
                err => alert(err.message)
            );
    }


    // public updateRental(): void {
    //     this.rentalsService.updateRental(this.rental).subscribe(
    //         () => alert("עודכן"),
    //         err => alert(err.message));
    //     window.location.reload()
    // }
}



