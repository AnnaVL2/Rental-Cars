import { Injectable } from '@angular/core';
import {Branch} from '../models/branch';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class BranchesService {

  constructor(private httpClient: HttpClient) { }

  private allBranchesUrl = "http://localhost:64284/api/branches/all"
  public getAllBranches(): Observable<Branch[]> {
      return this.httpClient.get<Branch[]>(this.allBranchesUrl);
  }
}
