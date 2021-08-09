using System.Collections.ObjectModel;
using Arelic.Models;
using Arelic.ViewModels.MainWindowPages;
using Reactive.Bindings;

//using Reactive.Bindings;

namespace Arelic.ViewModels
{
    public class MainWindowViewModel
    {
        public AuthPageViewModel AuthPageViewModel { get;}
        public ObservableCollection<Block> Blocks { get; } = new();

        public ReactiveProperty<bool> IsEditMode { get; } = new();

        public MainWindowViewModel(AuthPageViewModel authPageViewModel)
        {
            AuthPageViewModel = authPageViewModel;
        }
    }
}
