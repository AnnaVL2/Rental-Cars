import { Component, OnInit } from '@angular/core';
import { UploadService } from 'src/app/services/upload.service';
import { UsersService } from 'src/app/services/users.services';
import { User } from 'src/app/models/user';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

    public user = new User();
    private image: File;
    usersService: any;
    public roleID = 1;


    public constructor(private uploadService: UploadService, usersService: UsersService) { }
    
    ngOnInit() {
    }

    public addUser(): void {
        this.usersService
            .addUser(this.user)
            .subscribe(
                user => {
                    alert("done" + user.userID);

                    // Adding the image with the ID.
                    this.uploadService
                        .uploadImage(this.image, +user.userID)
                        .subscribe(
                            () => alert("Done"),
                            err => alert("Error!" + err.message)
                        );
                },
                err => alert(err.message));
    }

    public onFileSelect(args): void {
        this.image = args.target.files[0];
    }
}