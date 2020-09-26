using ForSale.ComunDll.Responses;
using ForSale.XamarinApp.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSale.XamarinApp.ViewModels
{
    public class QualificationDetailPageViewModel : ViewModelBase
    {
        private QualificationResponse _qualification;

        public QualificationDetailPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.Qualification;
        }

        public QualificationResponse Qualification
        {
            get => _qualification;
            set => SetProperty(ref _qualification, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("qualification"))
            {
                Qualification = parameters.GetValue<QualificationResponse>("qualification");
            }
        }
    }

}
