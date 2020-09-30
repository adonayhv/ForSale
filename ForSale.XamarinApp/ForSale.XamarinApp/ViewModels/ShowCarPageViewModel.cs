using ForSale.ComunDll.Helpers;
using ForSale.ComunDll.Models;
using ForSale.XamarinApp.Helpers;
using ForSale.XamarinApp.ItemViewModels;
using ForSale.XamarinApp.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ForSale.XamarinApp.ViewModels
{
    public class ShowCarPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<ProductItemViewModel> _products;
        private bool _isRunning;
        private bool _isEnabled;
        private decimal _totalValue;
        private int _totalItems;
        private float _totalQuantity;
        private DelegateCommand _clearAllCommand;
        private DelegateCommand _finishOrderCommand;

        public ShowCarPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = Languages.ShowShoppingCar;
            IsEnabled = true;
        }

        public DelegateCommand ClearAllCommand => _clearAllCommand ?? (_clearAllCommand = new DelegateCommand(ClearAllAsync));

        public DelegateCommand FinishOrderCommand => _finishOrderCommand ?? (_finishOrderCommand = new DelegateCommand(FinishOrderAsync));

        public decimal TotalValue
        {
            get => _totalValue;
            set => SetProperty(ref _totalValue, value);
        }

        public int TotalItems
        {
            get => _totalItems;
            set => SetProperty(ref _totalItems, value);
        }

        public float TotalQuantity
        {
            get => _totalQuantity;
            set => SetProperty(ref _totalQuantity, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public ObservableCollection<ProductItemViewModel> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            List<OrderDetail> orderDetails = JsonConvert.DeserializeObject<List<OrderDetail>>(Settings.OrderDetails);
            if (orderDetails == null)
            {
                orderDetails = new List<OrderDetail>();
            }

            TotalItems = orderDetails.Count;
            TotalValue = orderDetails.Sum(od => od.Value).Value;
            TotalQuantity = orderDetails.Sum(od => od.Quantity);

            Products = new ObservableCollection<ProductItemViewModel>(orderDetails.Select(od => new ProductItemViewModel(_navigationService)
            {
                Category = od.Product.Category,
                Description = od.Product.Description,
                Id = od.Product.Id,
                IsActive = od.Product.IsActive,
                IsStarred = od.Product.IsStarred,
                Name = od.Product.Name,
                Price = od.Product.Price,
                ProductImages = od.Product.ProductImages,
                Qualifications = od.Product.Qualifications,
                Quantity = od.Quantity,
                Remarks = od.Remarks
            }).ToList());
        }

        private async void FinishOrderAsync()
        {
            await _navigationService.NavigateAsync(nameof(FinishOrderPage));
        }

        private async void ClearAllAsync()
        {
            bool answer = await App.Current.MainPage.DisplayAlert(Languages.Delete, Languages.ClearAllConfirm, Languages.Yes, Languages.No);
            if (!answer)
            {
                return;
            }

            List<OrderDetail> orderDetails = new List<OrderDetail>();
            Settings.OrderDetails = JsonConvert.SerializeObject(orderDetails);
            await _navigationService.NavigateAsync($"/{nameof(OnSaleMasterDetailPage)}/NavigationPage/{nameof(ProductsPage)}");
        }
    }


}
