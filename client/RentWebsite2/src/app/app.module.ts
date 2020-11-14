import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from './app-routing.module';
import { LayoutComponent } from './components/general/layout/layout.component';

import { HeaderComponent } from './components/general/header/header.component';
import { FooterComponent } from './components/general/footer/footer.component';
import { MainComponent } from './components/general/main/main.component';
import { HomeComponent } from './components/home/home.component';
import { MenuComponent } from './components/menu/menu.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { AddUserComponent } from './components/user-manage/add-user/add-user.component';
import { UsersComponent } from './components/user-manage//users/users.component';
import { FormsModule } from '@angular/forms';
import { AddVehicleComponent } from './components/vehicle-manage/add-vehicle/add-vehicle.component';
import { AddVehicleTypeComponent } from './components/v-type-manage/add-vehicle-type/add-vehicle-type.component';
import { AddRentalComponent } from './components/rental-manage/add-rental/add-rental.component';
import { VehicleTypesManageComponent } from './components/v-type-manage/vehicle-types-manage/vehicle-types-manage.component';
import { VehiclesComponent } from './components/vehicle-manage/vehicles/vehicles.component';
import { RentalsComponent } from './components/rental-manage/rentals/rentals.component';
import { ThumbnailComponent } from './components/general/thumbnail/thumbnail.component';
import { UpdateUserComponent } from './components/user-manage/update-user/update-user.component';
import { AdminComponent } from './components/admin/admin.component';
import { PageNotFoundComponent } from './components/general/page-not-found/page-not-found.component';
import { ContactComponent } from './components/general/contact/contact.component';
import { SearchCarComponent } from './components/rental-manage/search-car/search-car.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { BranchComponent } from './components/general/branch/branch.component';
import { MercedesComponent } from './components/vehicle-manage/mercedes/mercedes.component';
import { LogoutComponent } from './components/logout/logout.component';


@NgModule({
  declarations: [
    HeaderComponent,
    LayoutComponent,
    FooterComponent,
    MainComponent,
    HomeComponent,
    MenuComponent,
    RegisterComponent,
    LoginComponent,
    AddUserComponent,
    UsersComponent,
    AddVehicleComponent,
    AddVehicleTypeComponent,
    AddRentalComponent,
    VehicleTypesManageComponent,
    VehiclesComponent,
    RentalsComponent,
    ThumbnailComponent,
    UpdateUserComponent,
    AdminComponent,
    PageNotFoundComponent,
    ContactComponent,
    SearchCarComponent,
    EmployeeComponent,
    BranchComponent,
    MercedesComponent,
    LogoutComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],


  providers: [],
  bootstrap: [LayoutComponent]
})
export class AppModule { }
