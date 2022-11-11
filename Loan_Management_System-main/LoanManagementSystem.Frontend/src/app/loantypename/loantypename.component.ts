import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-loantypename',
  templateUrl: './loantypename.component.html',
  styleUrls: ['./loantypename.component.css']
})
export class LoantypenameComponent implements OnInit {

  public loantype?: Loantypes;
  public name: string = "Gold_Loan";
  constructor(http: HttpClient) {
    http.get<Loantypes>('https://localhost:7061/api/Loans/getLoanTypeDetails/' + this.name).subscribe(result => {
      this.loantype = result;
      console.log(result);
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}

interface Loantypes {
  id: number;
  loanTypeName: string;
  interestRate: number;
}
