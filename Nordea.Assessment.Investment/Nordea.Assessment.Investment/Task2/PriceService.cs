using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nordea.Assessment.Investment.Models;

namespace Nordea.Assessment.Investment.Task2
{
    public class PriceService
    {
        public async Task<Price[]> GetPricesFromWebService1()
        {
            return await Task.FromResult(new Price[0]); //Method implementation
        }

        public async Task<Price[]> GetPricesFromWebService2()
        {
            return await Task.FromResult(new Price[0]); //Method implementation
        }

        public async Task<Price[]> GetPricesFromWebService3() //Method implementation
        {
            return await Task.FromResult(new Price[0]);
        }

        public async Task<Price[]> GetPrices()
        {
            var externalPrices = await Task.WhenAll(
                    GetPricesFromWebService1(),
                    GetPricesFromWebService2(),
                    GetPricesFromWebService3());

            var uniquePrices = new ConcurrentHashSet<Price>(new PriceComparer());

            var pricesQuery = externalPrices
                .AsParallel()
                .WithDegreeOfParallelism(3/*to perform iteration per each price result*/)
                .Select(prices => prices);

            pricesQuery.ForAll(x => AddUniquePrice(x, uniquePrices));

            return uniquePrices.ToArray();
        }

        private void AddUniquePrice(IEnumerable<Price> prices, ConcurrentHashSet<Price> hashSet)
        {
            foreach (var price in prices)
            {
                hashSet.Add(price);
            }
        }
    }
    public class PriceComparer : IEqualityComparer<Price>
    {
        public bool Equals(Price x, Price y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            return string.Equals(x.ProductKey, y.ProductKey, StringComparison.InvariantCultureIgnoreCase)
                   && x.Date == y.Date;
        }

        public int GetHashCode(Price obj)
        {
            // Or implement more adequate hash code for Price
            return obj.ProductKey.GetHashCode() + obj.Date.GetHashCode() + obj.Value.GetHashCode();
        }
    }

    //Self implemented ConcurrentHashSet due to lack of this data structure in standard .net library
    public class ConcurrentHashSet<T>
    {
        public ConcurrentHashSet(IEqualityComparer<T> comparer)
        {
            _data = new HashSet<T>(comparer);
        }

        private readonly HashSet<T> _data;

        public void Add(T val)
        {
            lock (_data) _data.Add(val);
        }

        public void Remove(T val)
        {
            lock (_data) _data.Remove(val);
        }

        public T[] ToArray()
        {
            lock (_data)
            {
                return _data.ToArray();
            }
        }
    }
}
