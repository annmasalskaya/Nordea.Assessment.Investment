using System;
using Nordea.Assessment.Investment.Models;

namespace Nordea.Assessment.Investment.Task3
{
    public class PriceManager
    {
        //From Task3 description I made a suggestion that we are able to inject IPriceDataSource
        //So it allows us to define concrete implementation of IPriceDataSource at runtime

        private readonly IPriceDataSource _priceDataSource;

        public PriceManager(IPriceDataSource priceDataSource)
        {
            _priceDataSource = priceDataSource ?? throw new ArgumentNullException(nameof(priceDataSource));
        }

        public Price[] GetPrices()
        {
            // currently returns prices from source
            // should return interpolated prices
            return _priceDataSource.GetPrices();
        }
    }
}