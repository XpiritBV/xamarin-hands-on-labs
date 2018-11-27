using Quotes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quotes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditQuotePage : ContentPage
    {
        private Quote _original;
        private Quote _workingCopy;
        private bool _isNew => _original == null;

        public EditQuotePage() : this(null)
        {
        }

        public EditQuotePage(Quote quote)
        {
            _original = quote;
            if (!_isNew)
            {
                _workingCopy = new Quote(quote);
            }
            else
            {
                _workingCopy = new Quote();
            }

            BindingContext = _workingCopy;
            InitializeComponent();
        }

        async void SaveQuote(object sender, System.EventArgs e)
        {
            if (_isNew)
            {
                QuoteManager.Instance.Quotes.Add(_workingCopy);
            }
            else
            {
                _original.Author = _workingCopy.Author;
                _original.QuoteText = _workingCopy.QuoteText;
            }
            await Navigation.PopAsync();
        }
    }
}