using CommunityToolkit.Mvvm.ComponentModel;

namespace SampleMauiApp.ViewModels
{
    public partial class BaseViewModel : ObservableValidator
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool _isBusy;
        public bool IsNotBusy => !IsBusy;

        [ObservableProperty]
        private string? _title;
        
    }
}
