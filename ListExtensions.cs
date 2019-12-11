using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace santa_shares
{
    public static class ListExtensions
    {
        public static T RandomItem<T>(this IEnumerable<T> list, Random randomSource)
        {
            int idx = randomSource.Next(list.Count());
            return list.Skip(idx).FirstOrDefault();
        }

        public static T RandomItem<T>(this T[] list, Random randomSource)
        {
            int idx = randomSource.Next(list.Count());
            return list.Skip(idx).FirstOrDefault();
        }
    }
}