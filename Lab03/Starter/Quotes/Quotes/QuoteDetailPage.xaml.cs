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
	public partial class QuoteDetailPage : ContentPage
	{
        public QuoteDetailPage(Quote quote)
        {
            BindingContext = quote;
            InitializeComponent();
        }
    }
}