using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CRUD.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Commentaire { get; set; }
    }
}
