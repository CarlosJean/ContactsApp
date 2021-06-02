using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.Entities {
    public class Group {
        public int ID { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Contact> Contacts { get; set; }

    }
}
