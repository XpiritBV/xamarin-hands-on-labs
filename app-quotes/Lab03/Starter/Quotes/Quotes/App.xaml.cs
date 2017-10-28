using Quotes.Data;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Quotes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            new QuoteManager(DependencyService.Get<IQuoteLoader>());

            MainPage = new NavigationPage(new Quotes.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected async override void OnSleep()
        {
            await Task.Run(() =>
            {
                QuoteManager.Instance.Save();
            });
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
