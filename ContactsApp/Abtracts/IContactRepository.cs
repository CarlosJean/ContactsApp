using ContactsApp.DTOs;
using ContactsApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.Abtracts {
    public interface IContactRepository {
        public Contact Contact(int contactId);
        public IEnumerable<Contact> Contacts { get;}
        public ContactPosted Save(ContactDTO contact);
        public ContactPosted Update(int contactId, ContactDTO contact);
        public ContactPosted Delete(int contactId);
    }
}
