using System.Collections.Generic;

namespace SharePrices.Models
{
    public interface ISharesRepository
    {
        IEnumerable<Shares> AllShares { get; }
    }
}
