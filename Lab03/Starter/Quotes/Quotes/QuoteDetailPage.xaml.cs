using Quotes.Data;
using Xamarin.Forms;

namespace Quotes
{
	public partial class QuoteDetailPage : ContentPage
    {
		public QuoteDetailPage(Quote quote)
        {
            BindingContext = quote;
			InitializeComponent();
        }
    }
}