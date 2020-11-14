import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";
import { Credentials } from '../models/credentials';
import { Router } from "@angular/router";

@Injectable({
    providedIn: 'root'
})

export class UsersService {
    public user: User;

    public constructor(private httpClient: HttpClient) { }

    private allUsersUrl = "http://localhost:64284/api/users/all"
    public getAllUsers(): Observable<User[]> {
        return this.httpClient.get<User[]>(this.allUsersUrl);
    }

    private addUserUrl = "http://localhost:64284/api/users/newUser";
    public addUser(user: User): Observable<User> {
        return this.httpClient.post<User>(this.addUserUrl, user);
    }

    private deleteUserUrl = "http://localhost:64284/api/users/delete";
    public deleteUser(id: number): Observable<undefined> {
        return this.httpClient.delete<undefined>(this.deleteUserUrl + "/" + id);
    }

    private getOneUserUrl = "http://localhost:64284/api/users/one";
    public getUser(id: number): Observable<undefined> {
        return this.httpClient.get<undefined>(this.getOneUserUrl + "/" + id);
    }

    private updateUserUrl = "http://localhost:64284/api/users/update";
    public updateUser(id: number): Observable<User> {
        return this.httpClient.put<User>(this.updateUserUrl, id);
    }

    private allRolesUrl = "http://localhost:64284/api/users/allRoles";
    public getAllRoles(): Observable<User[]> {
        return this.httpClient.get<User[]>(this.allRolesUrl);
    }

    //login
    private loginUrl = "http://localhost:64284/api/users/login";

    // public login(userName:string, password:string):Observable<User>{
    //     return this.httpClient.post<User>(this.loginUrl,{userName,password});
    // }

    public login2(credentials: Credentials): boolean {
        // if(credentials.roleID === 1) {
        if (credentials.userName === "maryd" && credentials.password === "123456") {

            // than server returnes a user object describing this client:
            const user = {
                userName: "maryd",
                firstName: "Mary",
                lastName: "Dance",
                roleID: 1
            };
            this.user = user;
            localStorage.setItem("user", JSON.stringify(user));
            return true;
        }


        // else if (credentials.roleID === 2) {
        else if (credentials.userName === "ooollll" && credentials.password === "123456") {
            const user = {
                userName: "ooollll",
                firstName: "Chloe",
                lastName: "Dance",
                roleID: 2
            };
            this.user = user;
            localStorage.setItem("user", JSON.stringify(user));
            return true;
        }

        // else if (credentials.roleID === 3) {
        else if (credentials.userName === "menta" && credentials.password === "123456") {
            const user = {
                userName: "menta",
                firstName: "Rose",
                lastName: "Menta",
                roleID: 3
            };
            this.user = user;
            this.user.roleID === 3;
            localStorage.setItem("user", JSON.stringify(user));
            return true;
        }

        else {
            return false;
        }
    }
}