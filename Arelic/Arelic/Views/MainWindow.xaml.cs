using System.Windows.Navigation;
using Arelic.ViewModels;
using Arelic.Views.MainWindowPages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Animation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Arelic.Views
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private MainWindowViewModel ViewModel { get; }
        public MainWindow(MainWindowViewModel viewModel)
        {
            this.InitializeComponent();
            ViewModel = viewModel;
            ContentFrame.Navigate(typeof(AuthPage), ViewModel.AuthPageViewModel, new DrillInNavigationTransitionInfo());
        }
    }
}
