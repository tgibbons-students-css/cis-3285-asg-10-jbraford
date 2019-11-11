using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyTrader.Contracts;

namespace CurrencyTrader.AdoNet
{
    public class AsyncTradeStorage : ITradeStorage
    {
        private readonly ILogger logger;
        private ITradeStorage SynchTradeStorage;

        public AsyncTradeStorage(ILogger logger)
        {
            this.logger = logger;
            SynchTradeStorage = new AdoNetTradeStorage(logger);
        }
        public void Persist(IEnumerable<TradeRecord> trades)
        {
            logger.LogInfo("Starting synchronous trade storage");
            // SynchTradeStorage.Persist(trades);
            Task.Run(() => SynchTradeStorage.Persist(trades));
        }
    }
}
