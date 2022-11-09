import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MustMatch } from './_helpers/must-match.validator';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Component({
  selector: 'app-user-registeration',
  templateUrl: './user-registeration.component.html',
  styleUrls: ['./user-registeration.component.css']
})

export class UserRegisterationComponent implements OnInit {
   userForm:FormGroup
  constructor(private formBuilder: FormBuilder, private http: HttpClient) { }

  ngOnInit() {
    this.userForm = this.formBuilder.group({
      custname: [''],
      email: [''],
      pan: [''],
      phoneno: [''],
      custAddress: ['']
    });
  }

  onSubmit(){
    var fomValue = this.userForm.value;
     if(this.userForm.valid){
      alert('Signed up')
      console.log(this.userForm.value);
      var temp={
        "id":null,
        "custname": this.userForm.value.custname,
        "email": this.userForm.value.email,
        "pan": this.userForm.value.pan,
        "phoneno": this.userForm.value.phoneno,
        "custAddress": this.userForm.value.custAddress
      }
      this.http.post<any>('https://localhost:7061/api/Profile/Profile', temp)
      .subscribe((response)=>{
        console.log('repsonsei ',response);
      });
      
    } else {
      alert('Invalid details')
      
    }
  }

}