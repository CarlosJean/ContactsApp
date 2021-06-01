using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.Entities {
    public class Contact {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int GroupID { get; set; }
        public Group Group { get; set; }
    }
}
