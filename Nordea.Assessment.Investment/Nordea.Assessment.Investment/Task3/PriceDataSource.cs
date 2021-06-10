using System;
using Nordea.Assessment.Investment.Models;

namespace Nordea.Assessment.Investment.Task3
{
    public abstract class PriceDataSource : IPriceDataSource
    {
        public virtual Price[] GetPrices()
        {
            // currently returns prices from source (with gaps)
            throw new NotImplementedException();
        }
    }
}
