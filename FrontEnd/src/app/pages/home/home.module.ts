import { NgModule } from '@angular/core';
import { HomeInitComponent } from './home-init/home-init.component';
import { HomeRoutingModule } from './home.routing.module';

@NgModule({
  imports: [
   // SharedModule,
    HomeRoutingModule,
  //  CalendarModule,
   // IMaskModule
  ],
  declarations: [HomeInitComponent]
})
export class HomeModule { }