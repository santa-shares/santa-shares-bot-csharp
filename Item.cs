using System;
using System.Collections.Generic;
using System.Text;

namespace santa_shares
{
    public class Item
    {
        public string item_name { get; set; }
        public int item_id { get; set; }
        public int price { get; set; }
        public int amount {get;set;}
    }

    public class Items
    {
        public Item[] ItemsList { get; set; }
    }
}
