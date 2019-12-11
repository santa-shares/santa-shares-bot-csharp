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
        public int balance { get; set; }
        public int stock_value { get; set; }
        public int total { get; set; }
        public Item[] items {get;set;}
    }

    public class Users
    {
        public User[] AllUsers { get; set; }
    }
}
