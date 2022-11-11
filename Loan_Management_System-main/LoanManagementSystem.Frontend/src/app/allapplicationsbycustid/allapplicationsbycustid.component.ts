import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-allapplicationsbycustid',
  templateUrl: './allapplicationsbycustid.component.html',
  styleUrls: ['./allapplicationsbycustid.component.css']
})
export class AllapplicationsbycustidComponent implements OnInit {
  public loanapps?: LoanApps[];
  public id: number = 1;

  constructor(http: HttpClient) {
    http.get<LoanApps[]>('https://localhost:7061/api/LoanApplications/getApplicationByCustomerId/' + this.id).subscribe(result => {
      this.loanapps = result;
      console.log(result);
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}

interface LoanApps {
  id: number;
  loanType: any;
  loanTypeId: number;
  cust: any;
  customerInfoId: number;
  amount: number;
  interest: number;
  months: number;
  bankDetailId: number;
  bankDetail: any;
}
