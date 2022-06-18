import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';





@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    
    HttpClientModule,    
    RouterModule
    
  ],
  declarations: [
    NavbarComponent
    
  ],
  exports:[
    // shared modules
    BrowserModule,
    
    HttpClientModule,
   

    // shared components
    NavbarComponent
  ]
})
export class CoreModule { }