using System.Collections.Generic;

namespace SharePrices.Models
{
    public class SharesRepository : ISharesRepository
    {
        private readonly ShareDbContext _shareDbContext;



        public SharesRepository(ShareDbContext shareDbContext)

        {
            _shareDbContext = shareDbContext;
        }

        public IEnumerable<Shares> AllShares
        {
            get
            {
                return _shareDbContext.Share;
            }
        }

    }
}
