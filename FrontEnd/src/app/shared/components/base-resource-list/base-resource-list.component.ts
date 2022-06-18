import { HttpEventType } from '@angular/common/http';
import { OnInit, Directive, Input, Output } from '@angular/core';


import { BaseResourceModel } from "../../models/base-resource.model";
import { BaseResourceService } from "../../services/base-resource.service";

@Directive()
export abstract class BaseResourceListComponent<T extends BaseResourceModel> implements OnInit {

  @Input() public disabled?: boolean;
  @Input() public fileName?: string;
 // @Output() public downloadStatus: EventEmitter<progressstatus>;

  resources: T[] = [];

  constructor(private resourceService: BaseResourceService<T>) { }

  ngOnInit() {
    console.log('errr')
    this.resourceService.getAll().subscribe(
      (resources:any) => this.resources = resources.data.sort((a:any,b:any) => b.id - a.id),
      error => alert('Erro ao carregar a lista')
    )   
  }

  deleteResource(resource: T) {
    const mustDelete = confirm('Deseja realmente excluir este item?');
    
    if (mustDelete){
      const ident : any = resource.id
      this.resourceService.delete(ident).subscribe(
        () => this.resources = this.resources.filter(element => element != resource),
        () => alert("Erro ao tentar excluir!")
      )
    }
  }

  //downloadFile(file: string, id : number) {
  //     this.resourceService.downloadFile(file, id).subscribe(
   //     () => this.resources = this.resources.filter(element => element != resource),
   //     () => alert("Erro ao tentar excluir!")
   //   )
   // }
  

  downloadFile(file: string, id : number) {
    //this.downloadStatus.emit( {status: ProgressStatusEnum.START});
    this.resourceService.downloadFile(file, id).subscribe(
      (data:any) => {
        switch (data.type) {
          case HttpEventType.DownloadProgress:
            ///this.downloadStatus.emit( {status: ProgressStatusEnum.IN_PROGRESS, percentage: Math.round((data.loaded / data.total) * 100)});
            break;
          case HttpEventType.Response:
           // this.downloadStatus.emit( {status: ProgressStatusEnum.COMPLETE});
            const downloadedFile = new Blob([data.body], { type: data.body.type });
            const a = document.createElement('a');
            a.setAttribute('style', 'display:none;');
            document.body.appendChild(a);
            //a.download = this.fileName;
            a.href = URL.createObjectURL(downloadedFile);
            a.target = '_blank';
            a.click();
            document.body.removeChild(a);
            break;
        }
      },
      error => {
      //this.downloadStatus.emit( {status: ProgressStatusEnum.ERROR});
      }
    );
  }


}
