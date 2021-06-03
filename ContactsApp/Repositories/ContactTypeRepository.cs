using ContactsApp.Abtracts;
using ContactsApp.Data;
using ContactsApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.Repositories {
    public class ContactTypeRepository : IContactTypeRepository {
        ContactsAppDbContext context;
        public ContactTypeRepository(ContactsAppDbContext contactsAppDbContext) {
            this.context = contactsAppDbContext;
        }

        public IEnumerable<ContactType> ContactTypes { get { return this.context.ContactTypes.ToList(); } }
    }
}
