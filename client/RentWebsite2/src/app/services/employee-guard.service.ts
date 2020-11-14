import { Injectable } from '@angular/core';
import { CanActivate, Router, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class EmployeeGuardService implements CanActivate {

    public constructor(private router: Router) { }
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        let user: any = localStorage.getItem("user");

        if (user === null) {
            this.router.navigate(["/login"]);
            return false;
        }

        user = JSON.parse(user);

        if (user.roleID !== 2) {
            this.router.navigate(["/login"]);
            return false;
        }

        return true;
    }
}
