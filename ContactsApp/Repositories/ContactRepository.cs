using ContactsApp.Abtracts;
using ContactsApp.Data;
using ContactsApp.DTOs;
using ContactsApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.Repositories {
    public class ContactRepository : IContactRepository {
        ContactsAppDbContext context;
        public ContactRepository(ContactsAppDbContext contactsAppDbContext) {
            this.context = contactsAppDbContext;
        }

        IEnumerable<Contact> IContactRepository.Contacts { get { return this.context.Contacts; } }

        public Contact Contact(int contactId) {
            var contact = this.context.Contacts
                .Include(x=>x.Group)
                .Include(x=>x.ContactContactTypes)
                .Where(c => c.ID == contactId)
                .FirstOrDefault();

            return contact;
        }

        public ContactPosted Delete(int contactId) {
            try {
                var contact = this.context.Contacts.Where(c=>c.ID == contactId).FirstOrDefault();
                var contactContactTypes = this.context.ContactContactTypes.Where(c=>c.ContactID == contactId).ToList();

                foreach (var contactContactType in contactContactTypes) {
                    this.context.ContactContactTypes.Remove(contactContactType);
                }

                this.context.Contacts.Remove(contact);
                this.context.SaveChanges();

                var contactPosted = new ContactPosted() {
                    Code = 200,
                    Message = "Contacto eliminado satisfactoriamente."
                };
                return contactPosted;

            } catch (Exception) {

                throw;
            }
        }

        public ContactPosted Save(ContactDTO contactDto) {
            try {

                //Save contact
                var contact = new Contact() {
                    Name = contactDto.name,
                    Email = contactDto.email,
                    GroupID = Convert.ToInt32(contactDto.group_id)
                };

                this.context.Contacts.Add(contact);
                this.context.SaveChanges();

                foreach (var contactNumber in contactDto.contact_numbers) {
                    var contactContactType = new ContactContactType() {
                        ContactID = contact.ID,
                        ContactTypeID = Convert.ToInt32(contactNumber.contact_type),
                        Number = contactNumber.phone_number
                    };
                    
                    this.context.ContactContactTypes.Add(contactContactType);
                }

                this.context.SaveChanges();
                var contactPosted = new ContactPosted() {
                    Code = 200,
                    Message = "Contacto guardado satisfactoriamente."
                };
                return contactPosted;

            } catch (Exception) {

                throw;
            }
        }

        public ContactPosted Update(int contactId, ContactDTO contactDto) {
            try {
                var contact = this.context.Contacts.Where(c => c.ID == contactId).FirstOrDefault();

                //Validación
                if (contact != null) {
                    contact.Name = contactDto.name;
                    contact.Email = contact.Email;
                    contact.GroupID = Convert.ToInt32(contactDto.group_id);
                }

                var contactContactTypes = this.context.ContactContactTypes.Where(c => c.ContactID == contactId).ToList();

                foreach (var contactNumber in contactDto.contact_numbers) {
                    var contactContactType = this.context
                        .ContactContactTypes
                        .Where(c => c.ContactID == contactId && c.ContactTypeID == Convert.ToInt32(contactNumber.contact_type));

                    var contactNumberExists = contactContactType.Count();

                    if (contactNumberExists > 0) {
                        contactContactType.FirstOrDefault().Number = contactNumber.phone_number;
                        continue;
                    } else {
                        this.context.Add(new ContactContactType() {
                            ContactID = contact.ID,
                            ContactTypeID = Convert.ToInt32(contactNumber.contact_type),
                            Number = contactNumber.phone_number
                        });
                    }
                }

                this.context.SaveChanges();
                var contactPosted = new ContactPosted() {
                    Code = 200,
                    Message = "Contacto actualizado satisfactoriamente."
                };
                return contactPosted;
            } catch (Exception) {

                throw;
            }            
        }

        
    }
}
