using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace Login.Model
{

    [Table("user")]
    public class User
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100), Unique]
        public string Username { get; set; }

        [MaxLength(100), Unique]
        public string Email { get; set; }
        [MaxLength(70)]
        public string Password { get; set; }

    }

}
