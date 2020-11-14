import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user';
import { UsersService } from 'src/app/services/users.services';
import { UploadService } from 'src/app/services/upload.service';



@Component({
    selector: 'app-add-user',
    templateUrl: './add-user.component.html',
    styleUrls: ['./add-user.component.css']
})
export class AddUserComponent {

    public user = new User();
    private image: File;

    public constructor(private usersService: UsersService, private uploadService: UploadService) { }

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
