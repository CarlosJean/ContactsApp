import { Component, OnInit } from '@angular/core';
import { ContactTypeService } from 'src/app/services/contact-type/contact-type.service';
import { FormControl,FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { ContactService } from 'src/app/services/contact/contact.service';
import { Contact } from 'src/app/models/contact';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})
export class ContactFormComponent implements OnInit {

  contactTypes:any = [];
  header:string = "";
  constructor(private fb:FormBuilder,private contactTypeService:ContactTypeService, private contactService:ContactService, private route:ActivatedRoute) { }
  contactForm = this.fb.group({
    name :[''],
    email:[''],
    phone_number:[''],
    cellphone_number:[''],
    group:[''],
  });

  ngOnInit(): void {
    this.getContactTypes();
    let formType = this.route.snapshot.url[0].path;
    this.header = (formType == "update") ? "Actualizar contacto" : "Agregar contacto.";
  }

  getContactTypes():void{
    this.contactTypeService.getContactTypes().subscribe((res)=>{
      this.contactTypes = res;
    });
  }

  ngOnSubmit():void{
    let values = this.contactForm.value;
    let contact:Contact = {name : values.name, email:values.email,group_id:"1",contact_numbers:[{phone_number : values.phone_number,contact_type:"1"},{phone_number : values.cellphone_number,contact_type:"2"}]};
    this.contactService.saveContact(contact).subscribe((res)=>{
      alert(res.message);
    });
  }
}
