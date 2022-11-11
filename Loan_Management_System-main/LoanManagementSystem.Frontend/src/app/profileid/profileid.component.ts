import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-profileid',
  templateUrl: './profileid.component.html',
  styleUrls: ['./profileid.component.css']
})
export class ProfileidComponent implements OnInit {

  public profile?: GetProfiles;
  public id: number = 1;
  constructor(http: HttpClient) {
    http.get<GetProfiles>('https://localhost:7061/api/Profile/' + this.id).subscribe(result => {
      this.profile = result;
      console.log(result);
    }, error => console.error(error));

  }
  title = 'LoanManagementSystem.Frontend';
  ngOnInit(): void {
  }

}

interface GetProfiles {
  id: number;
  custname: string;
  email: string;
  pan: string;
  phoneno: string;
  emis: Array<any>;
  loanApplications: Array<any>;
  custAddress: string
}
