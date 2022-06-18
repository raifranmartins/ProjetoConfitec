import { Component, Injector, OnInit, EventEmitter } from '@angular/core';
import { AbstractControl, Validators } from '@angular/forms';
import { BaseResourceFormComponent } from 'src/app/shared/components/base-resource-form/base-resource-form.component';
import { Category } from '../../categories/shared/scholarity.model';
import { CategoryService } from '../../categories/shared/scholarity.service';
import { Entry } from '../shared/user.model';
import { EntryService } from '../shared/user.service';
import { FileUploader} from 'ng2-file-upload';
import { FileUploadModule } from 'ng2-file-upload';
import { FormsModule } from '@angular/forms';
import { Observable, ReplaySubject } from 'rxjs';
import { Validacoes } from 'src/app/shared/models/validations';
import { NotificationService } from 'src/app/shared/services/notification.service';



@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent extends BaseResourceFormComponent<Entry> {
  



  categories: Category[] = [];
  submitted = false;
  //file?: File;
  localUrl: any;
  public selectedFile?: File;
  public formData = new FormData();

  public base64Output : string = '';
  
  
  constructor(
    protected entryService: EntryService,
    protected categoryService: CategoryService,
    protected injector2: Injector,    
    protected notify : NotificationService
  ) {
    super(injector2, new Entry(), entryService, notify)

    
  }

  override ngOnInit() : void {
    this.loadCategories();
    this.buildResourceForm()
    console.log(this.currentAction)
    super.ngOnInit();   
    

    
  }





 /* initFilds(){    
    this.resourceForm = this.formBuilder.group(
      {
        name: [
          '',
          Validators.compose([Validators.required,])
        ],
        surname: [
          '',
          Validators.compose([Validators.required,])
        ],
        email: [
          '',
          Validators.compose([Validators.required,])
        ],
        birthDate: [
          '',
          Validators.compose([Validators.required,])
        ],
        scholarityId: [
          0,
          Validators.compose([Validators.required,])
        ],
        fileSource: [
          '',
          Validators.compose([Validators.required,])
        ],
      })
    }
  */

    get f() {
      return this.resourceForm.controls;
    }

  protected buildResourceForm() {
    if(this.currentAction == 'new')
      this.resourceFormNew()
    else
      this.resourceFormEdit()    
   // 
  } 




 // onSelectFile(fileInput: any) {
 //   this.selectedFile = <File>fileInput.target.files[0];
 // }

  
 onFileChange(event : any) {
    
    var file : File = event.target.files[0]    
    this.convertFile(file).subscribe((base64:any) => {
      this.base64Output = base64;
      this.resourceForm.value.fileSource = this.base64Output;
      this.resourceForm.value.SchoolRecordsName = file.name;
      this.resourceForm.value.SchoolRecordsType = file.name.split('.').pop();
    });
  }
  convertFile(file : File) : Observable<string> {
    const result = new ReplaySubject<string>(1);
    const reader = new FileReader();
    reader.readAsBinaryString(file);
    reader.onload = (event) => result.next(btoa(event.target!.result!.toString()));
    return result;
  }


  
  


  submitForm(data: any) {
    this.submittingForm = true;
    if (this.resourceForm.invalid) {
      return;
    }
    this.resourceForm.value.scholarityId =
      parseInt(this.resourceForm.value.scholarityId)
    if (this.currentAction == "new")
      this.createResource();
    else // currentAction == "edit"
      this.updateResource();
  } 


  private loadCategories(){
    this.categoryService.getAll().subscribe(
      (categories:any) => {this.categories = categories.data;
      console.log(this.categories)}
      
    );
    
  }

  protected override creationPageTitle(): string {
    return "Add Novo Usuário";
  }

  protected override editionPageTitle(): string {
    const resourceName = this.resource.name || "";
    return "Editando Usuário: " + resourceName;
  }

resourceFormNew(){
  this.resourceForm = this.formBuilder.group({         
    name: [null, [Validators.required]],
    surname: [null, [Validators.required]],
    email: [null, [Validators.required, Validators.email]],
    birthDate: [null, [Validators.required, Validacoes.ValidaData]],      
    scholarityId: [null, [Validators.required]],
    fileSource: [null,[Validators.required]],
    SchoolRecordsName: [null],
    SchoolRecordsType: [null]
  });
}

resourceFormEdit(){
  this.resourceForm = this.formBuilder.group({  
    id: [''],    
    name: [null, [Validators.required]],
    surname: [null, [Validators.required]],
    email: [null, [Validators.required, Validators.email]],
    birthDate: [null, [Validators.required, Validacoes.ValidaData]],      
    scholarityId: [null, [Validators.required]],
    schoolRecordsId: [null, [Validators.required]],
    //fileSource: [null,[Validators.required]],
    //SchoolRecordsName: [null],
    //SchoolRecordsType: [null]
  });
}

}
