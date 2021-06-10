using Nordea.Assessment.Investment.Models;

namespace Nordea.Assessment.Investment.Task3
{
    public interface IPriceDataSource
    {
        Price[] GetPrices();
    }
}