import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-bankdetails',
  templateUrl: './bankdetails.component.html',
  styleUrls: ['./bankdetails.component.css']
})
export class BankdetailsComponent implements OnInit {

  public bankdetails?: BankDetails[];

  constructor(http: HttpClient) {
    http.get<BankDetails[]>('https://localhost:7061/api/BankDetail/getAllBankDetails').subscribe(result => {
      this.bankdetails = result;
      console.log(result);
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}

interface BankDetails {
  id: number;
  bankName: string;
  bankAddress: string;
}
