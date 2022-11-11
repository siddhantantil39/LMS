import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {

  public profiles?: GetProfiles[];
  constructor(http: HttpClient) {

    http.get<GetProfiles[]>('https://localhost:7061/api/Profile/getAllProfiles').subscribe(result => {
      this.profiles = result;
      console.log(result);
    }, error => console.error(error));
  }

  title = 'LoanManagementSystem.Frontend';

}

interface Emis {
  
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
