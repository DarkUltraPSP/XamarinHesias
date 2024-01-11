using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using CRUD.Models;

namespace CRUD
{
    public class ContactDatabaseService
    {
        readonly SQLiteConnection database;

        public ContactDatabaseService(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<Contact>();
        }

        public List<Contact> GetContacts()
        {
            return database.Table<Contact>().ToList();
        }

        public Contact GetContact(int id)
        {
            return database.Get<Contact>(id);
        }

        public int SaveContact(Contact contact)
        {
            if (contact.Id != 0)
            {
                database.Update(contact);
                return contact.Id;
            }
            else
            {
                return database.Insert(contact);
            }
        }

        public int DeleteContact(Contact contact)
        {
            return database.Delete(contact);
        }
    }
}
