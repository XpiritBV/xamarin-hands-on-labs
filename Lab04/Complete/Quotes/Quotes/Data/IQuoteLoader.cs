using System.Collections.Generic;

namespace Quotes.Data
{
    public interface IQuoteLoader
    {
        IEnumerable<Quote> Load();
        void Save(IEnumerable<Quote> quotes);
    }
}