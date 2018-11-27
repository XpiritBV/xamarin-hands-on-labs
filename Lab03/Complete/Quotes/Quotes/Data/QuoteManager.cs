using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Quotes.Data
{
    public class QuoteManager
    {
        public static QuoteManager Instance { get; private set; }

        readonly IQuoteLoader loader;

        public ObservableCollection<Quote> Quotes { get; private set; }

        public QuoteManager(IQuoteLoader loader)
        {
            if (Instance != null)
                throw new Exception("Can only create a single QuoteManager.");
            Instance = this;
            this.loader = loader;
            Quotes = new ObservableCollection<Quote>(loader.Load());
        }

        public void Save()
        {
            loader.Save(Quotes);
        }
    }
}
