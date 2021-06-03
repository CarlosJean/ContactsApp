import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from 'src/app/models/contact';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  private baseUrl = 'https://localhost:44369/api/contact';
  constructor(private http:HttpClient) { }

  getContacts():Observable<any>{
    return this.http.get(this.baseUrl);
  }

  getContact(contactId:number):Observable<any>{
    let url:string = `${this.baseUrl}/${contactId}`;
    return this.http.get(url);
  }

  saveContact(contact:Contact):Observable<any>{
    let body = JSON.stringify(contact);
    
    return this.http.post(this.baseUrl,body,{headers:new HttpHeaders({ 'Content-Type': 'application/json' })});
  }

  updateContact(contactId:number,contact:Contact):Observable<any>{
    let body = JSON.stringify(contact),
    url = `${this.baseUrl}/${contactId}`;;
    
    return this.http.put(url,contact,{headers:new HttpHeaders({ 'Content-Type': 'application/json' })});
  }

  deleteContact(contactId:number):Observable<any>{
    let url = `${this.baseUrl}/${contactId}`;
    return this.http.delete(url);
  }
}
