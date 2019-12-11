

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace santa_shares
{
    public class Trader{

        private User user{get;set;}
        private AuthenticationHeaderValue auth {get;set;}

        public Trader(User user){
            this.user = user;
            auth = new AuthenticationHeaderValue("token",user.token);
        }

        public void Run(){
            
        }

        private async Task<Items> GetItemList()
        {
            HttpClient client = new HttpClient();
            Items items = await client.GetTypeAsJsonAsync<Items>(Program.APIUrl + "items", auth);
            return items;
        }

        private async Task<bool> Buy(Item item, int qty)
        {
            Item itemRequest = new Item(){
                item_id = item.item_id,
                amount = qty
            };
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsJsonAsync(Program.APIUrl + "buy",itemRequest,auth);
            return httpResponseMessage.StatusCode==System.Net.HttpStatusCode.Created;
        }

        private async Task<bool> Sell(Item item, int qty)
        {
            Item itemRequest = new Item(){
                item_id = item.item_id,
                amount = qty
            };
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsJsonAsync(Program.APIUrl + "sell",itemRequest,auth);
            return httpResponseMessage.StatusCode==System.Net.HttpStatusCode.Created;
        }
    }
}