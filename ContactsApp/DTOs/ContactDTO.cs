using ContactsApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.DTOs {
    public class ContactDTO {
        public string name { get; set; }
        public string email { get; set; }
        public string group_id { get; set; }
        public ContactNumbersDTO[] contact_numbers { get; set; }
    }
}
