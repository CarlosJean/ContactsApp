import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactDetailsComponent } from './contact-details/contact-details.component';
import { ContactFormComponent } from './contact-form/contact-form.component';
import { ContactComponent } from './contact.component';

const routes: Routes = [
  { path: '', component: ContactComponent },
  { path: 'create', component: ContactFormComponent },
  { path: 'details/:id', component: ContactDetailsComponent },
  { path: 'update/:id', component: ContactFormComponent } 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContactRoutingModule { }
