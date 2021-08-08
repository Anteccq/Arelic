using System.Collections.ObjectModel;
using Arelic.Models;
//using Reactive.Bindings;

namespace Arelic.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Block> Blocks { get; } = new();

        //public ReactiveProperty<bool> IsEditMode { get; } = new();
    }
}
