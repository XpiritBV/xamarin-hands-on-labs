using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Plugin.TextToSpeech;
using Xamarin.Forms;

namespace Quotes.Data
{
    public class QuoteManager
    {
        public static QuoteManager Instance { get; private set; }

        readonly IQuoteLoader loader;

        public ObservableCollection<Quote> Quotes { get; private set; }

        public QuoteManager(IQuoteLoader loader)
        {
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
			await CrossTextToSpeech.Current.Speak(text);
		}
    }
}
