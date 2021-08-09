using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Arelic.ViewModels.MainWindowPages;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Arelic.Views.MainWindowPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AuthPage : Page
    {
        private AuthPageViewModel AuthPageViewModel { get; set; }
        public AuthPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.AuthPageViewModel = e.Parameter as AuthPageViewModel;
            this.DataContext = AuthPageViewModel;
        }
    }
}
