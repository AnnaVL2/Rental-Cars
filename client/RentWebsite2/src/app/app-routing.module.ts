import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent} from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';

import { RegisterComponent } from './components/register/register.component';
import { UsersComponent } from './components/user-manage//users/users.component';
import { AddUserComponent } from './components/user-manage/add-user/add-user.component';
import { VehicleTypesManageComponent } from './components/v-type-manage/vehicle-types-manage/vehicle-types-manage.component';
import { RentalsComponent} from './components/rental-manage/rentals/rentals.component';

import {AddRentalComponent} from './components/rental-manage/add-rental/add-rental.component';
import { AddVehicleTypeComponent} from './components/v-type-manage/add-vehicle-type/add-vehicle-type.component';
import { AddVehicleComponent} from './components/vehicle-manage/add-vehicle/add-vehicle.component';
import { UpdateUserComponent } from './components/user-manage//update-user/update-user.component';
import { VehiclesComponent} from './components/vehicle-manage/vehicles/vehicles.component';
import { PageNotFoundComponent} from './components/general/page-not-found/page-not-found.component';
import { AdminComponent } from './components/admin/admin.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { LoginGuardService } from './services/login-guard.service';
import { ContactComponent } from './components/general/contact/contact.component';
import { SearchCarComponent} from './components/rental-manage/search-car/search-car.component';
import { BranchComponent } from './components/general/branch/branch.component';
import { MercedesComponent } from './components/vehicle-manage/mercedes/mercedes.component';

import { AdminGuardService } from './services/admin-guard.service';
import { EmployeeGuardService } from './services/employee-guard.service';



const routes: Routes = [
    {path: "home", component: HomeComponent},
    {path: "login", component: LoginComponent},
    {path: "logout", component: LogoutComponent},
    {path: "register", component: RegisterComponent},
    {path: "users", canActivate: [LoginGuardService], component: UsersComponent},
    {path: "add-user", component: AddUserComponent},
    {path: "contact", component: ContactComponent },
    {path: "branch", component: BranchComponent },

    {path: "vehicle-types-manage", canActivate: [LoginGuardService], component: VehicleTypesManageComponent},
    {path: "rentals", canActivate: [LoginGuardService], component: RentalsComponent},
    {path: "add-rental", canActivate: [LoginGuardService], component: AddRentalComponent},

    {path: "add-vehicle-type", component: AddVehicleTypeComponent},
    {path: "add-vehicle", component: AddVehicleComponent},

    {path: "search-car", component: SearchCarComponent},
    {path: "vehicles", canActivate: [LoginGuardService], component: VehiclesComponent},
    {path: "mercedes", component: MercedesComponent},

    {path: "update-user", component: UpdateUserComponent},
    {path: "admin", canActivate:[AdminGuardService], component: AdminComponent},
    // {path: "admin", component: AdminComponent},
    // {path:"employee", canActivate:[EmployeeGuardService],component:EmployeeComponent},
    {path:"employee", component: EmployeeComponent},

    {path: "", pathMatch: "full", redirectTo: "/home" },
    {path: "**", component: PageNotFoundComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
