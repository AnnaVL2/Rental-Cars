import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/services/users.services';
import { User } from 'src/app/models/user';
import { Role } from 'src/app/models/role';


@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})

export class UsersComponent implements OnInit {

    public allUsers: User[];
    public ok: boolean = true;
    public id: number;
    public allRoles: Role[];


  public constructor(private usersService: UsersService) { }

  public ngOnInit(): void {
      this.usersService.getAllUsers()
          .subscribe(
              users => this.allUsers = users,
              err => {
                  alert(err.message);
                  this.ok = false;
              },
              () => console.log("Done All."));

              
        this.usersService.getAllRoles().subscribe(
            r => this.allRoles = r,
            err => console.log(err.message)
          );
  }

public roleIDFunc(roleID: number): void{
    
}

public deleteUser(id:number): void{
    this.usersService.deleteUser(id)
    .subscribe(()=> alert ("user delete. id: " + id),
    err => 
        alert(err.message)
    //   () => console.log("User Deleted.")
    );
  }

  public updateUser (id:number): void{
      this.usersService.updateUser(id)
      .subscribe(()=> alert ("updated user, id: " + id),
      err =>
        alert(err.message)
      );
  }
}


