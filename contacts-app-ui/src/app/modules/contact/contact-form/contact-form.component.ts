import { Component, OnInit } from '@angular/core';
import { ContactTypeService } from 'src/app/services/contact-type/contact-type.service';
import { FormBuilder, FormArray } from '@angular/forms';
import { ContactService } from 'src/app/services/contact/contact.service';
import { Contact } from 'src/app/models/contact';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})
export class ContactFormComponent implements OnInit {

  isCreateContactForm:boolean = true;;
  contactTypes:any = [];
  header:string = "";
  constructor(private fb:FormBuilder,private contactTypeService:ContactTypeService, private contactService:ContactService, private route:ActivatedRoute) { }
  contactForm = this.fb.group({
    name :[''],
    email:[''],
    contacts: this.fb.array([
      this.fb.group({
        phone_number:[''],
        contact_type:['']
      })
    ])
    
  });

  get contacts() {
    return this.contactForm.get('contacts') as FormArray;
  }

  addContacts(phoneNumber:string = '', contact_type:string='') {
    this.contacts.push(this.fb.group({
      phone_number:[phoneNumber],
      contact_type:[contact_type]
    }));
  }

  removeContact(formControlId:number){
    //Función para remover controles del formulario.
    this.contacts.removeAt(formControlId);
  }

  ngOnInit(): void {
    this.getContactTypes();
    let formType = this.route.snapshot.url[0].path;
    this.header = (formType == "update") ? "Actualizar contacto" : "Agregar contacto.";
    if (formType == "update") {
      this.header = "Actualizar contacto";
      this.isCreateContactForm = false;
      this.contactData();
    } else {      
      this.header = "Agregar contacto.";
    }
  }

  getContactTypes():void{
    this.contactTypeService.getContactTypes().subscribe((res)=>{
      this.contactTypes = res;
    });
  }

  ngOnSubmit():void{

    let values = this.contactForm.value;
    let contact:Contact = {name : values.name, email:values.email,group_id:"1",contact_numbers:values.contacts};

    if (this.isCreateContactForm) {
      this.contactService.saveContact(contact).subscribe((res)=>{
        alert(res.message);
      });  
    }else{
      let contactId = this.route.snapshot.params.id;
      this.contactService.updateContact(contactId,contact).subscribe((res)=>{
        alert(res.message);
      });
    }
  }

  contactData():void{
    //Función para obtener los datos del contacto cuando se desee modificar.
    let contactId = this.route.snapshot.params.id;
    this.contactService.getContact(contactId).subscribe((res)=>{
      this.fillContactForm(res);
    });
  }

  fillContactForm(contactData:any){
    let contactDataArranged:any = {name:contactData.Name,email:contactData.Email,contacts:[]}
    contactData.ContactContactTypes.forEach((contact:any) => {
      contactDataArranged.contacts.push({phone_number:String(contact.Number),contact_type:String(contact.ContactType.ID)});
    });

    console.log(contactDataArranged);

    for (let index = 1; index < contactDataArranged.contacts.length; index++) {
      this.addContacts();      
    }

    //Función para llenar el formulario con los datos del cotacto.
    this.contactForm.setValue(contactDataArranged);

  }
}
