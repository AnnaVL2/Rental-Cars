import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/models/user';
import { UsersService } from 'src/app/services/users.services';
import { UploadService } from 'src/app/services/upload.service';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';



@Component({
    selector: 'app-update-user',
    templateUrl: './update-user.component.html',
    styleUrls: ['./update-user.component.css']
})

export class UpdateUserComponent implements OnInit {

    public oneUser: User[];
    public ok: boolean = true;
    public user: User;


    public id: number;
    public userID: number;
    private image: File;

    
    // public getOneUserUrl = "http://localhost:64284/api/users/one";
    // public displayUserID = this.httpClient.get<undefined>(this.getOneUserUrl + "/" + this.id);


    public constructor(private usersService: UsersService, private uploadService: UploadService, private httpClient: HttpClient) { }

    ngOnInit(): void {
        this.usersService.getUser(this.id)
        .subscribe(
            user => this.oneUser = user,
            err => {
                alert(err.message);
                this.ok = false;
            },
            () => console.log ("Done All")
        );
    }

    // העריכה לא פועלת, לא הצלחתי
    public updateUser(id:number): void {
        this.usersService
            .updateUser(id)
            .subscribe(
                user => {
                    alert("user update done" + id);

                    this.uploadService
                        .uploadImage(this.image, + user.userID)
                        .subscribe(
                            () => alert("Done"),
                            err => alert("Error!" + err.message)
                        );
                },
                err => alert(err.message));
    }

    // public updateUser (id:number): void{
    //     this.usersService.updateUser(id)
    //     .subscribe(()=> alert ("updated user, id: " + id),
    //     err =>
    //       alert(err.message)
    //     );
    // }


    public onFileSelect(args): void {
        this.image = args.target.files[0];
    }
}







