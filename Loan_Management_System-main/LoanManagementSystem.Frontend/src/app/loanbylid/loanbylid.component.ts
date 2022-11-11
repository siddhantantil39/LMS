import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-loanbylid',
  templateUrl: './loanbylid.component.html',
  styleUrls: ['./loanbylid.component.css']
})
export class LoanbylidComponent implements OnInit {

  public loan?: Loans;
  public id: number = 1;

  constructor(http: HttpClient) {
    http.get<Loans>('https://localhost:7061/api/Loans/getLoanByLoanId/' + this.id).subscribe(result => {
      this.loan = result;
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
