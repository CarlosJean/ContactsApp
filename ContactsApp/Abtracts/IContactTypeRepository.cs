using ContactsApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.Abtracts {
    public interface IContactTypeRepository {
        public IEnumerable<ContactType> ContactTypes { get; }
    }
}
