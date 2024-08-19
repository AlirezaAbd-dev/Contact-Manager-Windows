using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts
{
    interface IContactsRepository
    {
        DataTable SelecteAll();
        DataTable SelectRow(int contactId);
        DataTable Search(string parameter);
        bool Insert(string name, string mobile, string email, int age, string address);
        bool Update(int contactId, string name, string mobile, string email, int age, string address);
        bool Delete(int contactId);
    }
}
