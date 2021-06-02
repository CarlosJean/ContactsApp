import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ContactRoutingModule } from './contact-routing.module';
import { ContactComponent } from './contact.component';
import { ContactService } from 'src/app/services/contact/contact.service';
import { ContactDetailsComponent } from './contact-details/contact-details.component';
import { ContactFormComponent } from './contact-form/contact-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ContactTypeService } from 'src/app/services/contact-type/contact-type.service';
import { Contact } from 'src/app/models/contact';
import { ContactType } from 'src/app/models/contact-type';

@NgModule({
  declarations: [
    ContactComponent,
    ContactDetailsComponent,
    ContactFormComponent
  ],
  imports: [
    CommonModule,
    ContactRoutingModule,
    ReactiveFormsModule
  ],
  providers:[ContactService,ContactTypeService/* , Contact,ContactType */]
})
export class ContactModule { }
