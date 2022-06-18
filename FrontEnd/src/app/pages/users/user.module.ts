import { NgModule} from '@angular/core';
//import { SharedModule } from "../../shared/shared.module";

//import { EntriesRoutingModule } from './entries-routing.module';

//import { EntryListComponent } from "./entry-list/entry-list.component";
//import { EntryFormComponent } from "./entry-form/entry-form.component";


//import { IMaskModule } from "angular-imask";
import { UserRoutingModule } from './user.routing.module';
import { UserFormComponent } from './user-form/user-form.component';
import { UserListComponent } from './user-list/user-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CalendarModule } from "primeng/calendar";

@NgModule({
  imports: [
    SharedModule,
    UserRoutingModule,
    CalendarModule
    
    
   // IMaskModule
  ],
  
  declarations: [UserListComponent, UserFormComponent]
})
export class UserModule { }