import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-getpaymentsbypid',
  templateUrl: './getpaymentsbypid.component.html',
  styleUrls: ['./getpaymentsbypid.component.css']
})
export class GetpaymentsbypidComponent implements OnInit {

  public payment?: GetPayment;
  public id?: number = 1;

  constructor(http: HttpClient) {
    http.get<GetPayment>('https://localhost:7061/api/Payments/getPaymentByPaymentId/' + this.id).subscribe(result => {
      this.payment = result;
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
