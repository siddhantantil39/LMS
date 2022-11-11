import { AuthGuard } from './guards/auth.guard';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { CustomersComponent } from './customer/customers.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { ProfileComponent } from './profile/profile.component';
import { ProfileidComponent } from './profileid/profileid.component';
import { AddpaymentComponent } from './addpayment/addpayment.component';
import { GetpaymentsbyidComponent } from './getpaymentsbyid/getpaymentsbyid.component';
import { GetpaymentsbypidComponent } from './getpaymentsbypid/getpaymentsbypid.component';
import { GetpaymentsbycustidComponent } from './getpaymentsbycustid/getpaymentsbycustid.component';
import { GetallpaymentsComponent } from './getallpayments/getallpayments.component';
import { AllloantypesComponent } from './allloantypes/allloantypes.component';
import { LoantypenameComponent } from './loantypename/loantypename.component';
import { LoanbycustidComponent } from './loanbycustid/loanbycustid.component';
import { LoanbylidComponent } from './loanbylid/loanbylid.component';
import { AllloansComponent } from './allloans/allloans.component';
import { AllapplicationsComponent } from './allapplications/allapplications.component';
import { AllapplicationsbycustidComponent } from './allapplicationsbycustid/allapplicationsbycustid.component';
import { AllapplicationsbyappidComponent } from './allapplicationsbyappid/allapplicationsbyappid.component';
import { CalculateemiComponent } from './calculateemi/calculateemi.component';
import { BankdetailsComponent } from './bankdetails/bankdetails.component';
import { BankdetailsbyidComponent } from './bankdetailsbyid/bankdetailsbyid.component';

@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent,
    ProfileidComponent,
    AddpaymentComponent,
    GetpaymentsbyidComponent,
    GetpaymentsbypidComponent,
    GetpaymentsbycustidComponent,
    GetallpaymentsComponent,
    AllloantypesComponent,
    LoantypenameComponent,
    LoanbycustidComponent,
    LoanbylidComponent,
    AllloansComponent,
    AllapplicationsComponent,
    AllapplicationsbycustidComponent,
    AllapplicationsbyappidComponent,
    CalculateemiComponent,
    BankdetailsComponent,
    BankdetailsbyidComponent,
    LoginComponent,CustomersComponent,HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
