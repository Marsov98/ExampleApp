using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using System.Windows;

namespace ExampleApp.BlazorDesktop
{
    public partial class App : IApplication
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}
