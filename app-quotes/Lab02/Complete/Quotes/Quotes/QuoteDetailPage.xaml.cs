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

		async void EditQuote(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new EditQuotePage(BindingContext as Quote));
		}
	}
}