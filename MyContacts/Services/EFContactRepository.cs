using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts
{
    class EFContactRepository : IContactsRepository
    {
        public ContactsEntities db = new ContactsEntities();

        public bool Delete(int contactId)
        {
            throw new NotImplementedException();
        }

        public bool Insert(string name, string mobile, string email, int age, string address)
        {
            throw new NotImplementedException();
        }

        public DataTable Search(string parameter)
        {
            throw new NotImplementedException();
        }

        public DataTable SelecteAll()
        {
            throw new NotImplementedException();
        }

        public DataTable SelectRow(int contactId)
        {
            throw new NotImplementedException();
        }

        public bool Update(int contactId, string name, string mobile, string email, int age, string address)
        {
            throw new NotImplementedException();
        }
    }
}
