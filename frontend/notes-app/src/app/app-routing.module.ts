import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNoteComponent } from './add-note/add-note.component';
import { LoginComponent } from './login/login.component';
import { EditNoteComponent } from './edit-note/edit-note.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
    { path: "", component: LoginComponent, pathMatch:"full" },
  	//{ path: "", component: HomeComponent, pathMatch:"full" },
    { path: "home", component: HomeComponent},
    { path: "add-note", component: AddNoteComponent},
    { path: "edit-note", component: EditNoteComponent},
    { path: '**', redirectTo: ''}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
