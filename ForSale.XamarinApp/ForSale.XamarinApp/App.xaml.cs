using Prism;
using Prism.Ioc;
using ForSale.XamarinApp.ViewModels;
using ForSale.XamarinApp.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using ForSale.ComunDll.Services;
using Syncfusion.Licensing;
//using ForSale.Dll.Entidades;

namespace ForSale.XamarinApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzE4MzYxQDMxMzgyZTMyMmUzMFZZZ3lTZ1N1a2N3VUpJaVdVa01Bcmw3NFhVNEZEWUZkTXh1alZOUW9BK009");

            InitializeComponent();

            await NavigationService.NavigateAsync($"NavigationPage/{nameof(ProductsPage)}");

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.Register<IApiService, ApiService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductsPage, ProductsPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductDetailPage, ProductDetailPageViewModel>();


        }
    }
}
