import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-allapplicationsbyappid',
  templateUrl: './allapplicationsbyappid.component.html',
  styleUrls: ['./allapplicationsbyappid.component.css']
})
export class AllapplicationsbyappidComponent implements OnInit {
  public loanapp?: LoanApps;
  public id: number = 1;

  constructor(http: HttpClient) {
    http.get<LoanApps>('https://localhost:7061/api/LoanApplications/getApplicationByApplicationId/' + this.id).subscribe(result => {
      this.loanapp = result;
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
