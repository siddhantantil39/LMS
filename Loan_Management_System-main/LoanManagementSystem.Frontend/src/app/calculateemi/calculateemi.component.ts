import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-calculateemi',
  templateUrl: './calculateemi.component.html',
  styleUrls: ['./calculateemi.component.css']
})
export class CalculateemiComponent implements OnInit {

  public months: number = 10;
  public amount: number = 500;
  public rate: number = 12;
  public value?: number;

  constructor(http: HttpClient) {
    http.get<number>('https://localhost:7061/api/EMICalculator/calculateEmi?months=' + this.months + '&amount=' + this.amount + '&rate=' + this.rate).subscribe(result => {
      this.value = result;
      console.log(result);
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}
