import { Component, OnInit } from '@angular/core';
import { BranchesService } from 'src/app/services/branches.service';
import { Branch } from 'src/app/models/branch';

@Component({
  selector: 'app-branch',
  templateUrl: './branch.component.html',
  styleUrls: ['./branch.component.css']
})
export class BranchComponent implements OnInit {

    public allBranches: Branch[];
    public ok: boolean = true;

  constructor(private branchesService: BranchesService) { }

  ngOnInit(): void {
//       this.branchesService.getAllBranches()
//         .subscribe(
//             branches => this.allBranches = branches,
//             err => {
//                 alert(err.message);
//                 this.ok = false;
//             },
//             () => console.log("Done!")
//         );
  }

}
