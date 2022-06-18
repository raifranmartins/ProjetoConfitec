import { AbstractControl } from "@angular/forms";

export class Validacoes {
  static ValidaData(controle: AbstractControl) {
    const birthDate = controle.value;    
    let date = new Date(Date.parse(birthDate));
    if (date > new Date()) {
        return { dataInvalida: true };
    }
    else {
        return null;
    }
    return null;
  }
  
}