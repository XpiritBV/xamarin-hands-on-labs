using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;

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

        public async Task SayQuote(Quote quote)
        {
            if (quote == null)
                throw new ArgumentNullException(nameof(quote));

            string text = quote.QuoteText;
            if (!string.IsNullOrWhiteSpace(quote.Author))
            {
                text += "; by " + quote.Author;
            }
            await TextToSpeech.SpeakAsync(text); // add using Xamarin.Essentials to the top of this C# file
        }
    }
}
