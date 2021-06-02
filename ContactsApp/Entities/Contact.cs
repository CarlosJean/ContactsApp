
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ContactsApp.Entities {
    public class Contact {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int GroupID { get; set; }
        [JsonIgnore]
        public Group Group { get; set; }

        public ICollection<ContactContactType> ContactContactTypes { get; set; }
    }
}
