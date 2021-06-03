using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ContactsApp.Entities {
    public class ContactContactType {
        public int ID { get; set; }
        [JsonIgnore]
        public int ContactID { get; set; }
        [JsonIgnore]
        public int ContactTypeID { get; set; }
        
        public ContactType ContactType { get; set; }
        [JsonIgnore]
        public Contact Contact { get; set; } 
        public string Number { get; set; }
    }
}
