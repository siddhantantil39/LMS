import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-getpaymentsbyid',
  templateUrl: './getpaymentsbyid.component.html',
  styleUrls: ['./getpaymentsbyid.component.css']
})
export class GetpaymentsbyidComponent implements OnInit {

  public payments?: GetPayment[];
  public id?: number = 2;

  constructor(http: HttpClient) {
    http.get<GetPayment[]>('https://localhost:7061/api/Payments/getPaymentsByEmiId/' + this.id).subscribe(result => {
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
