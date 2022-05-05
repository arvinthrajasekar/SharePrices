using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharePrices.Models
{
    public class SharesRepository : ISharesRepository
    {
        private readonly ShareDbContext _shareDbContext;



        public SharesRepository(ShareDbContext shareDbContext)

        {
            _shareDbContext = shareDbContext;
        }

        public IEnumerable<Shares> AllShares()
        {
            
                return _shareDbContext.Share;
            
        }

        public Shares GetShares(string name)
        {
            var res = _shareDbContext.Share.FirstOrDefault(s => s.Name == name);

            return res;
        }

        public Task CreateAsync(Shares shares)
        {
            _shareDbContext.Add(shares);
            return _shareDbContext.SaveChangesAsync();
        }
    }
}
