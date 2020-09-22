using ForSale.XamarinApp.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSale.XamarinApp.ViewModels
{
    public class ModifyUserPageViewModel : ViewModelBase
    {
        public ModifyUserPageViewModel(INavigationService navigationService)
          : base(navigationService)
        {
            Title = Languages.ModifyUser; ;
        }
    }
}
