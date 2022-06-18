import { Injectable, Injector } from '@angular/core';
import { Category } from "./scholarity.model";

import { BaseResourceService } from "../../../shared/services/base-resource.service";
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService extends BaseResourceService<Category> {

  constructor(protected injector1: Injector) {
    super(environment.urlApi + "Scholarities", injector1, Category.fromJson);
  }

}