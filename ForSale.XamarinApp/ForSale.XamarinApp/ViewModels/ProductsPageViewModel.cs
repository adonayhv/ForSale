using ForSale.ComunDll.Helpers;
using ForSale.ComunDll.Models;
using ForSale.ComunDll.Responses;
using ForSale.ComunDll.Services;

using ForSale.XamarinApp.Helpers;
using ForSale.XamarinApp.ItemViewModels;
using ForSale.XamarinApp.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Essentials;

namespace ForSale.XamarinApp.ViewModels
{
    public class ProductsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<ProductItemViewModel> _products;
        private bool _isRunning;

        private string _search;
        private List<ProductResponse> _myProducts;
        private DelegateCommand _searchCommand;
     
        private int _cartNumber;
        private DelegateCommand _showCartCommand;

        public ProductsPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.Products;
            LoadCartNumber();

            LoadProductsAsync();
        }
        public DelegateCommand ShowCartCommand => _showCartCommand ?? (_showCartCommand = new DelegateCommand(ShowCartAsync));
        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand = new DelegateCommand(ShowProducts));
        public int CartNumber
        {
            get => _cartNumber;
            set => SetProperty(ref _cartNumber, value);
        }

        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);
                ShowProducts();
            }
        }


        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }



        public ObservableCollection<ProductItemViewModel> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }



        private void LoadCartNumber()
        {
            List<OrderDetail> orderDetails = JsonConvert.DeserializeObject<List<OrderDetail>>(Settings.OrderDetails);
            if (orderDetails == null)
            {
                orderDetails = new List<OrderDetail>();
                Settings.OrderDetails = JsonConvert.SerializeObject(orderDetails);
            }

            CartNumber = orderDetails.Count;
        }

        private async void ShowCartAsync()
        {
            await _navigationService.NavigateAsync(nameof(ShowCarPage));
        }

       

      

        private async void LoadProductsAsync()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ConnectionError, Languages.Accept);
                return;
            }

            IsRunning = true;
            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetListAsync<ProductResponse>(
                url,
                "/api",
                "/Products");
            IsRunning = false;
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }

            _myProducts = (List<ProductResponse>)response.Result;
            ShowProducts();
        }

        private void ShowProducts()
        {
            if (string.IsNullOrEmpty(Search))
            {
                Products = new ObservableCollection<ProductItemViewModel>(_myProducts.Select(p => new ProductItemViewModel(_navigationService)
                {
                    Category = p.Category,
                    Description = p.Description,
                    Id = p.Id,
                    IsActive = p.IsActive,
                    IsStarred = p.IsStarred,
                    Name = p.Name,
                    Price = p.Price,
                    ProductImages = p.ProductImages,
                    Qualifications = p.Qualifications

                })
.ToList());
            }
            else
            {
                Products = new ObservableCollection<ProductItemViewModel>(_myProducts.Select(p => new ProductItemViewModel(_navigationService)
                {
                    Category = p.Category,
                    Description = p.Description,
                    Id = p.Id,
                    IsActive = p.IsActive,
                    IsStarred = p.IsStarred,
                    Name = p.Name,
                    Price = p.Price,
                    ProductImages = p.ProductImages,
                    Qualifications = p.Qualifications

                })
                    .Where(p => p.Name.ToLower().Contains(Search.ToLower()))
                    .ToList());

            }


        }

    }
}