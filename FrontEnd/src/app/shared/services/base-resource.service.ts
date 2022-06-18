import { BaseResourceModel } from "../models/base-resource.model";

import { Injector } from "@angular/core";
import { HttpClient, HttpEvent, HttpRequest } from "@angular/common/http";

import { Observable, throwError } from "rxjs";
import { map, catchError } from "rxjs/operators";


export abstract class BaseResourceService<T extends BaseResourceModel> {

  protected http: HttpClient;

  constructor(
    protected apiPath: string, 
    protected injector: Injector, 
    protected jsonDataToResourceFn: (jsonData: any) => T
  ){
    this.http = injector.get(HttpClient);    
  }

//  getAll(): Observable<T[]> {

 //   console.log('url', this.apiPath)
 //   return this.http.get(this.apiPath).pipe(
 //     map(this.jsonDataToResources.bind(this, [])),
 //     catchError(this.handleError)
 //   )
//  }
getAll(): Observable<T[]> {
 // return this.http.get(this.apiPath)
 // .pipe(map((res: any) => { 
  //  console.log('...', res)     
  //  return res;      
 // }))
console.log('fdsf')

 return this.http.get(this.apiPath).pipe(
  map(this.jsonDataToResource.bind(this)),
  catchError(this.handleError)      
)

}

  getById(id: number): Observable<T> {
    const url = `${this.apiPath}/${id}`;

    return this.http.get(url).pipe(
      map(this.jsonDataToResource.bind(this)),
      catchError(this.handleError)      
    )
  }

  create1(resource: T): Observable<T> {
    return this.http.post(this.apiPath, resource).pipe(
      map(this.jsonDataToResource.bind(this)),
      catchError(this.handleError)
    )
  }

  updateForm(resource: T): Observable<T> {
    const url = `${this.apiPath}`;

    return this.http.put(url, resource).pipe(
      map(() => resource),
      catchError(this.handleError)
    )
  }

  delete(id: number): Observable<any> {
    const url = `${this.apiPath}/${id}`;

    return this.http.delete(url).pipe(
      map(() => null),
      catchError(this.handleError)
    )
  }

  public downloadFile(file: string, id : number): Observable<HttpEvent<Blob>> {
    const url = `${this.apiPath}/Download`;
    return this.http.request(new HttpRequest(
      'GET',
      `${url}?file=${file}&id=${id}`,
      null,
      {
        reportProgress: true,
        responseType: 'blob'
      }));
  }

  

  // PROTECTED METHODS

  protected jsonDataToResources(jsonData: any[]): T[] {
    const resources: T[] = [];
    console.log('teste')
    jsonData.forEach(
      element => resources.push( this.jsonDataToResourceFn(element) )
    );
    return resources;
  }

  protected jsonDataToResource(jsonData: any): T {
    return this.jsonDataToResourceFn(jsonData);
  }

  protected handleError(error: any): Observable<any>{
    console.log("ERRO NA REQUISIÇÃO => ", error);
    return throwError(error);
  }

}