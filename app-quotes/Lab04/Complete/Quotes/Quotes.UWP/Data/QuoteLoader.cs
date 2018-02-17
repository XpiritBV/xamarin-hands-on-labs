using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using Xamarin.Forms;
using Quotes.Data;

[assembly: Dependency(typeof(QuoteLoader))]

namespace Quotes.Data
{
    public class QuoteLoader : IQuoteLoader
    {
        const string FileName = "quotes.xml";
        public IEnumerable<Quote> Load()
        {
            XDocument doc = null;

            string path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            string filename = Path.Combine(path, FileName);

            if (File.Exists(filename))
            {
                try
                {
                    using (var fs = File.OpenRead(filename))
                    {
                        doc = XDocument.Load(fs);
                    }
                }
                catch
                {
                }
            }

            if (doc == null)
                doc = XDocument.Parse(DefaultData);

            if (doc.Root != null)
            {
                foreach (var entry in doc.Root.Elements("quote"))
                {
                    yield return new Quote(
                        entry.Attribute("author").Value,
                        entry.Value);
                }
            }
        }

        public void Save(IEnumerable<Quote> quotes)
        {
            string path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            string filename = Path.Combine(path, FileName);

            if (File.Exists(filename))
                File.Delete(filename);

            XDocument doc = new XDocument(
                new XElement("quotes",
                    quotes.Select(q =>
                        new XElement("quote", new XAttribute("author", q.Author))
                        {
                            Value = q.QuoteText
                        })));
            using (var fs = File.OpenWrite(filename))
            {
                doc.Save(fs);
            }
        }

        #region Internal Data
        static string DefaultData =
            @"<?xml version=""1.0"" encoding=""UTF-8""?>
<quotes>
	<quote author=""Eleanor Roosevelt"">Great minds discuss ideas; average minds discuss events; small minds discuss people.</quote>
	<quote author=""William Shakespeare"">Some are born great, some achieve greatness, and some have greatness thrust upon them.</quote>
	<quote author=""Winston Churchill"">All the great things are simple, and many can be expressed in a single word: freedom, justice, honor, duty, mercy, hope.</quote>
	<quote author=""Ralph Waldo Emerson"">Our greatest glory is not in never failing, but in rising up every time we fail.</quote>
	<quote author=""William Arthur Ward"">The mediocre teacher tells. The good teacher explains. The superior teacher demonstrates. The great teacher inspires.</quote>
</quotes>";
        #endregion
    }
}