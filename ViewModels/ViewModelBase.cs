using System;
using MvvmHelpers;

namespace spacex_explore.ViewModels
{
    public class ViewModelBase : BaseViewModel
    {
        public ViewModelBase()
        {
        }

        private string _BusyText { get; set; } = "Hang on a second...";
        public string BusyText
        {
            get
            {
                return _BusyText;
            }
            set
            {
                _BusyText = value;
                OnPropertyChanged();
            }
        }
    }
}
