using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CRUD.Models
{
    internal class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Commentaire { get; set; }
    }
}
