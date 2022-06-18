import { Injectable, Injector } from '@angular/core';

import { Observable } from "rxjs";
import { flatMap, catchError, map } from "rxjs/operators";

import { BaseResourceService } from "../../../shared/services/base-resource.service";
import { CategoryService } from "../../categories/shared/scholarity.service";
import { Entry } from "./user.model";

import * as moment from "moment"
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})


export class EntryService extends BaseResourceService<Entry> {
  //private readonly API = environment.urlApi;

  constructor(protected injector1: Injector, private categoryService: CategoryService) { 
    super(environment.urlApi + "Users", injector1, Entry.fromJson);
  }


  create(entry: Entry): Observable<Entry> {
   return this.setCategoryAndSendToServer(entry, super.create1.bind(this));
  }

  update(entry: Entry): Observable<Entry> {
    return this.setCategoryAndSendToServer(entry, super.updateForm.bind(this))
  }

  getByMonthAndYear(month: number, year: number): Observable<Entry[]> {
    return this.getAll().pipe(
      map(entries => this.filterByMonthAndYear(entries, month, year))
    )
  }

 
  private setCategoryAndSendToServer(entry: Entry, sendFn: any): Observable<Entry>{
    let idparse : any = entry.scholarityId;
    //return this.categoryService.getById(entry.categoryId).pipe(
      return this.categoryService.getById(idparse).pipe(
      map((category : any) => {
        entry.scholarytyDescription = category;
        return sendFn(entry)
      }),
      catchError(this.handleError)
    );
  } 

  private filterByMonthAndYear(entries: Entry[], month: number, year: number) {
    return entries.filter((entry: any) => {
      const entryDate = moment(entry.date, "DD/MM/YYYY");
      const monthMatches = entryDate.month() + 1 == month;
      const yearMatches = entryDate.year() == year;

      if(monthMatches && yearMatches) return entry;
    })
  }

}