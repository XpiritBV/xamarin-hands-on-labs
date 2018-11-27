using Quotes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Quotes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = QuoteManager.Instance;
            InitializeComponent();
        }

        async void AddQuote(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new EditQuotePage());
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new QuoteDetailPage(e.SelectedItem as Quote));
            }
        }

        void OnDelete(object sender, System.EventArgs e)
        {
            if (sender is MenuItem item && item.CommandParameter is Quote quote)
            {
                QuoteManager.Instance.Quotes.Remove(quote);
            }
        }
    }
}
