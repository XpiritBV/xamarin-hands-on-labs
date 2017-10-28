using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Quotes.Data
{
    public class Quote : INotifyPropertyChanged
    {
        private string _author;
        private string _quoteText;

        public string Author
        {
            get { return _author; }
            set { SetPropertyValue(ref _author, value); }
        }

        public string QuoteText
        {
            get { return _quoteText; }
            set { SetPropertyValue(ref _quoteText, value); }
        }

        public Quote() : this("Unknown", "Quote goes here..")
        {
        }

        public Quote(Quote copy)
        {
            this.QuoteText = copy.QuoteText;
            this.Author = copy.Author;
        }

        public Quote(string author, string quoteText)
        {
            Author = author;
            QuoteText = quoteText;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        bool SetPropertyValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value) == false)
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
    }
}