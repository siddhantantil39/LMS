import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-getallpayments',
  templateUrl: './getallpayments.component.html',
  styleUrls: ['./getallpayments.component.css']
})
export class GetallpaymentsComponent implements OnInit {

  public payments?: GetPayment[];

  constructor(http: HttpClient) {
    http.get<GetPayment[]>('https://localhost:7061/api/Payments/getAllPayments').subscribe(result => {
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
