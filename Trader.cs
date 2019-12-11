

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace santa_shares
{
    public class Trader{

        private User user{get;set;}
        private Items inventory{get;set;}
        private AuthenticationHeaderValue auth {get;set;}

        private Random randomSource = new Random();

        public Trader(User user){
            this.user = user;
            auth = new AuthenticationHeaderValue("token",user.token);
        }

        public async Task Run(){
            while(true){
                //Buy an item
                Item[] items = await GetItemList();
                Item item = items.Where(i=>i.amount>0).RandomItem(randomSource);
                await Buy(item,randomSource.Next(item.amount+1));
                Thread.Sleep(60000);
                Item[] userItems = await GetUserInventory();
                Item item1 = userItems.RandomItem(randomSource);
                await Sell(item,randomSource.Next(item.amount+1));
            }
        }

        private async Task<Item[]> GetItemList()
        {
            HttpClient client = new HttpClient();
            Item[] items = await client.GetTypeAsJsonAsync<Item[]>(Program.APIUrl + "items", auth);
            return items;
        }

        private async Task<Item[]> GetUserInventory()
        {
            HttpClient client = new HttpClient();
            User userStatus = await client.GetTypeAsJsonAsync<User>(Program.APIUrl + "users/"+user.user_id, auth);
            return userStatus.items;
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