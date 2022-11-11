import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-allloans',
  templateUrl: './allloans.component.html',
  styleUrls: ['./allloans.component.css']
})
export class AllloansComponent implements OnInit {

  public loans?: Loans[];

  constructor(http: HttpClient) {
    http.get<Loans[]>('https://localhost:7061/api/Loans/getAllLoans').subscribe(result => {
      this.loans = result;
      console.log(result);
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}

interface Loans {
  id: number;
  amountTaken: number;
  loanType: any;
  loanTypeId: number;
  interest: number;
  amount: number;
  cust: any;
  customerInfoId: number;
  emiPayments: any;
  startDate: string;
  months: number;
  emiCompleted: boolean;
}
