import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

    public constructor(private router: Router) { }

  public ngOnInit(): void {
      localStorage.removeItem("user");
      this.router.navigate(["/home"])
  }

}
