import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-bankdetailsbyid',
  templateUrl: './bankdetailsbyid.component.html',
  styleUrls: ['./bankdetailsbyid.component.css']
})
export class BankdetailsbyidComponent implements OnInit {

  public bankdetail?: BankDetails;
  public id?: number=1;

  constructor(http: HttpClient) {
    http.get<BankDetails>('https://localhost:7061/api/BankDetail/getAllBankDetailsById/' + this.id).subscribe(result => {
      this.bankdetail = result;
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
