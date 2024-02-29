using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using DataTriggerCorruptedExample.ViewModels.Messages;
using MvvmHelpers.Commands;

namespace DataTriggerCorruptedExample.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public string mainPageTitle;

        public AsyncCommand DisplayAddNewStoreItemDialogCommand { get; set; }


        private byte _selectedViewModelIndex;
        public byte SelectedViewModelIndex
        {
            get => _selectedViewModelIndex;
            set
            {
                _selectedViewModelIndex = value;

                WeakReferenceMessenger.Default.Send(new SelectedViewChangedMessage(_selectedViewModelIndex));
            }
        }


        public MainPageViewModel()
        {
            MainPageTitle = "Store Calculations";

            SelectedViewModelIndex = 0;
        }
    }
}
