import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContactService } from 'src/app/services/contact/contact.service';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.css']
})
export class ContactDetailsComponent implements OnInit {

  contact:any = {};
  constructor(private contactService:ContactService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.getContact();
  }

  getContact(){
    let contactId = this.route.snapshot.params.id;
    this.contactService.getContact(contactId).subscribe((res)=>{
      this.contact = res;
      console.log(res);
    });
  }

  delete(){
    let confirmed = confirm("¿Seguro/a que desea eliminar este contacto?");
    if (!confirmed) { return; }

    let contactId = this.route.snapshot.params.id;
    this.contactService.deleteContact(contactId).subscribe((res)=>{
      if (res.code == 200) {
        alert(res.message);
      }
    });
  }
}
