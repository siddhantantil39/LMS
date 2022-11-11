import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-allloantypes',
  templateUrl: './allloantypes.component.html',
  styleUrls: ['./allloantypes.component.css']
})
export class AllloantypesComponent implements OnInit {

  public loantypes?: Loantypes[];

  constructor(http: HttpClient) {
    http.get<Loantypes[]>('https://localhost:7061/api/Loans/getAllLoanType/').subscribe(result => {
      this.loantypes = result;
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
