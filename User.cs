using System;
using System.Collections.Generic;
using System.Text;

namespace santa_shares
{
    public class User
    {
        public string user_name { get; set; }
        public int user_id { get; set; }
        public string token { get; set; }
    }

    public class Users
    {
        public User[] AllUsers { get; set; }
    }
}
