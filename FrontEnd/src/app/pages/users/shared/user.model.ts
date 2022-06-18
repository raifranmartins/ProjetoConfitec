import { BaseResourceModel } from "../../../shared/models/base-resource.model";
import { Category } from "../../categories/shared/scholarity.model";



export class Entry extends BaseResourceModel{
  constructor(
    //public id?: number,
    public name?: string,
    public surname?: string,
    public email?: string,
    public birthDate?: Date,
    public scholarityId? : number,
    public scholarytyDescription?: string,
    public schoolRecordsName? : string,
    public schoolRecordsId? : number,
  ){ 
    super();
  }


  static types = {
    expense: 'Despesa',
    revenue: 'Receita'
  };

  static fromJson(jsonData: any): Entry {
    return Object.assign(new Entry(), jsonData);
  }

 // get paidText(): string {
 //   return this.paid ? 'Pago' : 'Pedente';
 // }
}