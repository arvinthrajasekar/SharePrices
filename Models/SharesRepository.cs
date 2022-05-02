using System.Collections.Generic;
using System.Linq;

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
    }
}
