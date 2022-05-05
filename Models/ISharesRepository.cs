using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePrices.Models
{
    public interface ISharesRepository
    {
        IEnumerable<Shares> AllShares();

        Shares GetShares(string name);

        Task CreateAsync(Shares shares);
    }
}
