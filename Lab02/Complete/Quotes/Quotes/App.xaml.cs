using Quotes.Data;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Quotes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            new QuoteManager(DependencyService.Get<IQuoteLoader>());

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected async override void OnSleep()
        {
            // Handle when your app sleeps
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
