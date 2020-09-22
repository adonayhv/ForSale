using ForSale.XamarinApp.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSale.XamarinApp.ViewModels
{
    public class ShowCarPageViewModel : ViewModelBase
    {
        public ShowCarPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.ShowShoppingCar;
        }
    }
}
