import { Component, OnInit } from '@angular/core';
import { BaseResourceListComponent } from 'src/app/shared/components/base-resource-list/base-resource-list.component';
import { Entry } from "../shared/user.model";
import { EntryService } from '../shared/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent extends BaseResourceListComponent<Entry> {

  constructor(private entryService: EntryService) { 
    super(entryService);
    
  }

}
