import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';


@Injectable({
    providedIn: 'root'
})
//  הורשת אינטרפייס שיש לו פונקצית ההפעלה - אנחנו בוחרים האם להחזיר אמת או שקר באמצעותה
export class LoginGuardService implements CanActivate {

    public constructor(private router: Router) { }
// function for testing the role of the user and return true or false
// for allowing to enter to a specific route
    public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        let user = localStorage.getItem("user");
        if (user === null) {
            this.router.navigate(["/login"]);
            return false;
        }
        return true;
    }
}
