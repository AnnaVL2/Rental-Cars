import { Component, OnInit, DoCheck } from '@angular/core';
import { SearchCar } from 'src/app/models/search-car';
import { SearchCarService } from 'src/app/services/search-car.service';


@Component({
    selector: 'app-search-car',
    templateUrl: './search-car.component.html',
    styleUrls: ['./search-car.component.css']
})
export class SearchCarComponent implements OnInit, DoCheck {

    public isLoggedIn: boolean;
    public isUser: boolean;
    public isAdmin: boolean;

    public search = new SearchCar();
    public allCars: SearchCar[];
    public ok: boolean = false;
    public filteredCars: SearchCar[];
    public lastSearch: SearchCar[];
    public yearArr = ["2016", "2017", "2018", "2019", "2020"];
    public gearArr = ["auto", "manual"];


    public constructor(private searchService: SearchCarService) { }
    // ngDoCheck(): void {
    //     throw new Error("Method not implemented.");
    // }

    // ngDoCheck(): void {
    //     let user: any = localStorage.getItem("user");

    //     if (user === null) {
    //         this.isLoggedIn = false;
    //         this.isUser = false;
    //         this.isAdmin = false;
    //         return;
    //     }

    //     // Convert the string into a user object: 
    //     user = JSON.parse(user);

    //     if (user.role === 1) {
    //         this.isLoggedIn = true;
    //         this.isUser = true;
    //         this.isAdmin = false;
    //         return;
    //     }

    //     if (user.role === 2) {
    //         this.isLoggedIn = false;
    //         this.isUser = true;
    //         this.isAdmin = false;
    //         return;
    //     }

    //     if (user.role === 3) {
    //         this.isLoggedIn = true;
    //         this.isUser = false;
    //         this.isAdmin = true;
    //         return;
    //     }
    // }

    ngOnInit(): void {
    }
    //  חיפוש לפי תאריכים  
    public searchVehicles(pickupDate: Date, estimatedReturnDate: Date): void {
        this.ok = true;
        this.searchService.searchVehicles(pickupDate, estimatedReturnDate).subscribe(
            searchcars => {
                this.allCars = searchcars;
                this.filteredCars = searchcars
            },
            err => {
                alert(err.message);
                this.ok = false;
            },
            () => console.log("done"));
    }
    //  חיפוש לפי מודל  
    public onSearchModel(searchValue: string): void {
        this.filteredCars = this.allCars.filter(c =>
            c.model.toLowerCase().includes(searchValue.toLowerCase()));
    }
    //  חיפוש לפי יצרן  
    public onSearchManufacturer(searchValue: string): void {
        this.filteredCars = this.allCars.filter(c =>
            c.manufacturer.toLowerCase().includes(searchValue.toLowerCase()));
    }

    //  חיפוש לפי גיר  
    public onSearchGearType(gear: string): void {
        this.filteredCars = this.allCars.filter(c =>
            c.gearType.match(gear));
    }

    //חיפוש לפי שנה
    public onSearchYear(year: number): void {
        this.filteredCars = this.allCars.filter(c =>
            c.productionYear == year);
    }

    //חיפוש חופשי
    public onSearchChange(searchValue: string): void {
        this.filteredCars = this.allCars.filter(c =>
            c.model.includes(searchValue) || c.manufacturer.includes(searchValue));
    }

    //שמירה ללוקאל סטורג
    public writeToLocalStorage(car: SearchCar) {
        let arr = [];
        if (localStorage.getItem("search")) {
            arr = JSON.parse(localStorage.getItem("search"));
        }
        arr.push(car);
        localStorage.setItem("search", JSON.stringify(arr));
        console.log("done");
    }

    //שמירת מערך מלוקאל סטורג
    public ngDoCheck(): void {
        this.lastSearch = JSON.parse(localStorage.getItem("search"));
    }
}




