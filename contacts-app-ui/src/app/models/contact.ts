import { ContactType } from "./contact-type";

export class Contact {
    /**
     *
     */
    constructor(public name:string, public email:string, public group_id:string, public contact_numbers:ContactType[]) {
        
        
    }
}
