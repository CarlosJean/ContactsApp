import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactTypeService {

  private baseUrl = 'https://localhost:44369/api/contacttype/';
  constructor(private http:HttpClient) { }

  getContactTypes():Observable<any>{
    return this.http.get(this.baseUrl);
  }
}
