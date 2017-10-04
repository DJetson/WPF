using ShapeOptimization.ViewModels;
using ShapeOptimization.Views;
using System.Windows;

namespace ShapeOptimization
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow = new MainWindow() { DataContext = new MainWindowViewModel() };
            MainWindow.Show();
        }
    }
}
