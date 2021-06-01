using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.Entities {
    public class ContactContactType {
        public int ID { get; set; }
        public IEnumerable<ContactType> ContactTypes { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public string Number { get; set; }
    }
}
