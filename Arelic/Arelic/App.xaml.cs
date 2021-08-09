using Microsoft.UI.Xaml;
using System;
using Arelic.Models.Cryptography;
using Arelic.Models.Services;
using Arelic.Models.Storage;
using Arelic.ViewModels;
using Arelic.ViewModels.MainWindowPages;
using Arelic.Views;
using Arelic.Views.MainWindowPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Arelic
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {

            CreateDefaultBuilder((config, services) =>
            {
                services.AddSingleton<ICrypto, EyeCrypto>();
                services.AddSingleton<IStorage, FileStorage>();
                services.AddSingleton<IBlockService, BlockService>();
                services.AddSingleton<AuthPageViewModel>();
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<MainWindow>();
            }).GetService<MainWindow>()?.Activate();
        }

        private static ServiceProvider CreateDefaultBuilder(Action<IConfiguration, IServiceCollection> configureService)
        {
            IConfiguration config = new ConfigurationBuilder()
                .Build();
            IServiceCollection services = new ServiceCollection();
            configureService?.Invoke(config, services);
            return services.BuildServiceProvider();
        }
    }
}
