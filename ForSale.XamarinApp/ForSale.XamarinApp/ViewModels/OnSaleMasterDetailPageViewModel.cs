using ForSale.ComunDll.Helpers;
using ForSale.ComunDll.Models;
using ForSale.ComunDll.Responses;
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
    public class OnSaleMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private UserResponse _user;
        public OnSaleMasterDetailPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
            LoadUser();
        }
        private void LoadUser()
        {
            if (Settings.IsLogin)
            {
                TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
                User = token.User;
            }
        }

        public UserResponse User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
        {
            new Menu
            {
                Icon = "ic_card_giftcard",
                PageName = $"{nameof(ProductsPage)}",
                Title = Languages.Products
            },
            new Menu
            {
                Icon = "ic_shopping_cart",
                PageName = $"{nameof(ShowCarPage)}",
                Title = Languages.ShowShoppingCar
            },
            new Menu
            {
                Icon = "ic_history",
                PageName = $"{nameof(ShowHistoryPage)}",
                Title = Languages.ShowPurchaseHistory,
                IsLoginRequired = true
            },
            new Menu
            {
                Icon = "ic_person",
                PageName = $"{nameof(ModifyUserPage)}",
                Title = Languages.ModifyUser,
                IsLoginRequired = true
            },
            new Menu
            {
                Icon = "ic_exit_to_app",
                PageName = $"{nameof(LoginPage)}",
                Title = Languages.Login
            }
        };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title,
                    IsLoginRequired = m.IsLoginRequired
                }).ToList());
        }
    }

}
