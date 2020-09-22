using ForSale.XamarinApp.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSale.XamarinApp.ViewModels
{
    public class ShowHistoryPageViewModel : ViewModelBase
    {
        public ShowHistoryPageViewModel(INavigationService navigationService)
            :base (navigationService)
        {
            Title = Languages.ShowPurchaseHistory;
        }
    }
}
