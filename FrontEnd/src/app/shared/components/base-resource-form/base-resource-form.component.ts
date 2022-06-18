import { OnInit, AfterContentChecked, Injector, Directive } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

import { BaseResourceModel } from "../../models/base-resource.model"
import { BaseResourceService } from "../../services/base-resource.service"

import { switchMap } from "rxjs/operators";
import { NotificationService } from '../../services/notification.service';


//import toastr from "toastr";


@Directive()
export abstract class BaseResourceFormComponent<T extends BaseResourceModel> implements OnInit, AfterContentChecked{
  
  currentAction!: string;
  resourceForm!: FormGroup;
  pageTitle!: string;
  serverErrorMessages: string[] = [];
  submittingForm: boolean = false;
  objEdit : any;

  protected route: ActivatedRoute;
  protected router: Router;
  protected formBuilder: FormBuilder;

  constructor(
    protected injector: Injector,
    public resource: T,
    protected resourceService: BaseResourceService<T>,    
    //protected jsonDataToResourceFn: (jsonData  : any) => T,
    protected notifyService : NotificationService,
  ) { 
    this.route = this.injector.get(ActivatedRoute);
    this.router = this.injector.get(Router);
    this.formBuilder = this.injector.get(FormBuilder);
  }

  ngOnInit() {
    this.setCurrentAction();
    this.buildResourceForm();
    this.loadResource();
  }

  ngAfterContentChecked(){
    this.setPageTitle();
  }

/*  submitForm(){
    this.submittingForm = true;

    if (this.resourceForm.invalid) {
        return;
      } 

    if(this.currentAction == "new")
      this.createResource();
    else // currentAction == "edit"
      this.updateResource();
  } */


  // PRIVATE METHODS

  protected setCurrentAction() {
    if(this.route.snapshot.url[0].path == "new")
      this.currentAction = "new"
    else
      this.currentAction = "edit"
  }

  protected loadResource() {
    if (this.currentAction == "edit") {
      
      this.route.paramMap.pipe(
        switchMap((params:any) => this.resourceService.getById(+params.get("id")))
      )
      .subscribe(
        (resource: any) => {
          this.resource = resource.data;
          resource.data.birthDate = resource.data.birthDate.replace("T00:00:00","")

          this.resourceForm.patchValue(resource.data) 
          this.objEdit = resource.data
        },
        (error) => alert('Ocorreu um erro no servidor, tente mais tarde.')
      )
    }
  }


  protected setPageTitle() {
    if (this.currentAction == 'new')
      this.pageTitle = this.creationPageTitle();
    else{
      this.pageTitle = this.editionPageTitle();
    }
  }

  protected creationPageTitle(): string{
    return "Novo"
  }

  protected editionPageTitle(): string{
    return "Edição"
  }


  protected createResource(){

    
    //this.resourceForm.value.dia_aniversario = parseInt(this.form.value.dia_aniversario)

    const resource: any = this.resourceForm.value;



    //console.log('formulario', resource)

    this.resourceService.create1(resource)
      .subscribe(
        resource => this.actionsForSuccess(resource, "new"),
        error => this.actionsForError(error)
      )
  }


  protected updateResource(){
    const resource: any = this.resourceForm.value;
    console.log(resource)

    this.resourceService.updateForm(resource)
      .subscribe(resource => {
        this.actionsForSuccess(resource, 'edit')

      },
        error => {
          this.actionsForError(error)
        }
      )
  }

  
  protected actionsForSuccess(resource: T, action : string){
    if(action == "new"){
       this.notifyService.showSuccess("Registro Inserido com sucesso !!", "Usuário") 
       this.submittingForm = false; 
       this.resourceForm.reset();
    }else{
      this.notifyService.showSuccess("Registro Alterado com sucesso !!", "Usuário")
    }
    //const baseComponentPath: string | undefined = this.route.snapshot.parent?.url[0].path;  
   // this.submittingForm = false;
    
    // redirect/reload component page
    //this.router.navigateByUrl(baseComponentPath!, {skipLocationChange: true}).then(
     // () => this.router.navigate([baseComponentPath, resource.id, "users"])
    //)
  }


  protected actionsForError(error : any){
    this.notifyService.showError("Error na operação !!", "Usuário")

    this.submittingForm = false;

    if(error.status === 422)
      this.serverErrorMessages = JSON.parse(error._body).errors;
    else
      this.serverErrorMessages = ["Falha na comunicação com o servidor. Por favor, tente mais tarde."]
  }


  protected abstract buildResourceForm(): void;
}
