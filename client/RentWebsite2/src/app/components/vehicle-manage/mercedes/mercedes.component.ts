import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Rental } from 'src/app/models/rental';
import { AddRentalComponent } from 'src/app/components/rental-manage/add-rental/add-rental.component';
import { RentalsService } from 'src/app/services/rentals.service';

import { User } from 'src/app/models/user';
import { UsersService } from 'src/app/services/users.services';

import { Vehicle } from 'src/app/models/vehicle';
import { VehicleTypesManageService } from 'src/app/services/vehicle-types-manage.service';

import { HttpClient } from '@angular/common/http';


import { VehicleType } from 'src/app/models/vehicle-type';
import { VehiclesService } from 'src/app/services/vehicles.service';



@Component({
    selector: 'app-mercedes',
    templateUrl: './mercedes.component.html',
    styleUrls: ['./mercedes.component.css']
})
export class MercedesComponent implements OnInit {






    public constructor() { }

    ngOnInit() {

//         var slideIndex = 1;
// showSlides(slideIndex);

// function plusSlides(n) {
//   showSlides(slideIndex += n);
// }

// function currentSlide(n) {
//   showSlides(slideIndex = n);
// }

// function showSlides(n) {
//   let i;
//   let slides = document.getElementsByClassName("mySlides");
//   let dots = document.getElementsByClassName("dot");
//   if (n > slides.length) {slideIndex = 1}  
//   if (n < 1) {slideIndex = slides.length}
//   for (i = 0; i < slides.length; i++) {
//       slides[i].style.display = "none";  
//   }
//   for (i = 0; i < dots.length; i++) {
//       dots[i].className = dots[i].className.replace(" active", "");
//   }
//   slides[slideIndex-1].style.display = "block";  
//   dots[slideIndex-1].className += " active";
// }

    }
}
