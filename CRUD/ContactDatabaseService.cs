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
        private readonly SQLiteAsyncConnection db;

        public ContactDatabaseService(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Contact>();
        }

        public Task<List<Contact>> GetContactsAsync()
        {
            return db.Table<Contact>().OrderBy(c => c.LName).ToListAsync();
        }

        public Task<int> CreateContact(Contact contact)
        {
            return db.InsertAsync(contact);
        }

        public Task<int> UpdateContact(Contact contact)
        {
            return db.UpdateAsync(contact);
        }

        public Task<int> DeleteContact(Contact contact)
        {
            return db.DeleteAsync(contact);
        }
    }
}
