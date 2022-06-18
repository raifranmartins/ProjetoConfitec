import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeInitComponent } from './home-init/home-init.component';

const routes: Routes = [
  { path: '', component: HomeInitComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }