import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-allapplications',
  templateUrl: './allapplications.component.html',
  styleUrls: ['./allapplications.component.css']
})
export class AllapplicationsComponent implements OnInit {
  public loanapps?: LoanApps[];
  constructor(http: HttpClient) {
    http.get<LoanApps[]>('https://localhost:7061/api/LoanApplications/getAllApplications').subscribe(result => {
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
