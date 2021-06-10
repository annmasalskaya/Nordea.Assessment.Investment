using System;
using Nordea.Assessment.Investment.Models;

namespace Nordea.Assessment.Investment.Task3
{
    //Implemented with decorator pattern
    //https://en.wikipedia.org/wiki/Decorator_pattern
    public class InterpolatedPriceDataSource1 : PriceDataSource
    {
        public override Price[] GetPrices()
        {
            var prices = base.GetPrices();

            return GetInterpolatedPricesAlgorithm1(prices);
        }

        private Price[] GetInterpolatedPricesAlgorithm1(Price[] pricesFromSource)
        {
            // some logic here
            throw new NotImplementedException();
        }
    }
}
