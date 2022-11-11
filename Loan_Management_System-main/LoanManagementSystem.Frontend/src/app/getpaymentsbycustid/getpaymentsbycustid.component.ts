import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-getpaymentsbycustid',
  templateUrl: './getpaymentsbycustid.component.html',
  styleUrls: ['./getpaymentsbycustid.component.css']
})
export class GetpaymentsbycustidComponent implements OnInit {

  public payments?: GetPayment[];
  public id?: number = 1;

  constructor(http: HttpClient) {
    http.get<GetPayment[]>('https://localhost:7061/api/Payments/getPaymentsByCustomerId/' + this.id).subscribe(result => {
      this.payments = result;
      console.log(result);
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }
}

interface GetPayment {
  id: number;
  issueDate: any;
  emiAmount: any;
  paidOn: any;
  fine: number;
  emiId: number;
}
