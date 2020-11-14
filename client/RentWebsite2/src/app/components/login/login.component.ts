import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { UsersService } from 'src/app/services/users.services';
import { Router } from '@angular/router';
import { Credentials } from 'src/app/models/credentials';
import { User } from 'src/app/models/user';


@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent {

    public userLogin: User;
    public credentials = new Credentials();

    public constructor(private title: Title, private usersService: UsersService, 
        private router: Router) { }

    ngOnInit() {
        this.title.setTitle("LogIn")
    }

    // public login(): void {
    //     console.log(this.credentials.userName);
    //     console.log(this.credentials.password);

    //     this.usersService.login(this.credentials.userName, this.credentials.password).subscribe
    //         (details => {
    //             this.userLogin = details;
    //             localStorage.setItem("user", JSON.stringify(this.userLogin));
    //             if (this.credentials.userName === "menta" && this.credentials.password === "123456") {
    //                 // if (this.userLogin.roleID === 3) {
    //                 this.router.navigate(["/admin"]);
    //             }
    //             else if (this.userLogin.roleID === 2) {
    //                 this.router.navigate(["/employee"]);
    //             }
    //             else if (this.userLogin.roleID === 1) {
    //                 this.router.navigate(["/home"]);
    //             }
    //         },
    //             () => { alert("שם משתמש או סיסמא שגויים") }
    //         );
    // };

    public login3(): void {

        console.log(this.credentials.userName);
        console.log(this.credentials.password);

        if(this.usersService.login2(this.credentials)){
            if(this.usersService.user.roleID === 3){
                this.router.navigate(["/rentals"]);
            }
            else if (this.usersService.user.roleID === 2) {
                this.router.navigate(["/employee"]);
            }
            else if (this.usersService.user.roleID === 1) {
                this.router.navigate(["/add-rental"]);
            }
        }
        else{
            alert("שם משתמש או סיסמא שגויים");
        }
};


}
