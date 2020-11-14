import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UploadService {

    public constructor(private httpClient: HttpClient){}

    private addUserImageUrl="http://localhost:64284/api/upload/";
    public uploadImage(file: File, userID: number): Observable<null> {
    return this.httpClient.post<null>(this.addUserImageUrl + userID, file);
    }
}
