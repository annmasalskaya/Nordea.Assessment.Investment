using System;
using System.Linq;
using Nordea.Assessment.Investment.Models;

namespace Nordea.Assessment.Investment.Task1
{
    public class PriceCalculator
    {
        public void GetPositionPrices()
        {
            Price[] prices = GetPrices(); // can be more than 100000 records
            Position[] positions = GetPositions(); // can be more than 1000 records

            var positionPrices = from position in positions
                join price in prices
                    on position.ProductKey equals price.ProductKey
                select new
                {
                    ProductKey = position.ProductKey,
                    MarketValue = position.Amount * (decimal) price.Value,
                    PositionId = position.PositionId,
                };

            foreach (var item in positionPrices)
            {
                Console.WriteLine($"Product {item.ProductKey}; With Id: {item.PositionId}; With Value: {item.MarketValue}");
            }
        }

        private Position[] GetPositions()
        {
            throw new NotImplementedException();
        }

        private Price[] GetPrices()
        {
            throw new NotImplementedException();
        }
    }
}