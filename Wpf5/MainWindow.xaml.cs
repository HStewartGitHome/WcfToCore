using Shared.Client;
using Shared.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using Wcf5.Shared.ClientModels;
using Wpf5.Models;

namespace Wpf5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel viewModel = new MainViewModel
            {
                Models = new ObservableCollection<DetailModel>()
            };
            DataContext = (MainViewModel)viewModel;
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            MainViewModel viewModel = (MainViewModel)DataContext;
            TheGrid.ItemsSource = viewModel.Models;
        }

        private void OnSayHello(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            DetailObject details = RunClient.Execute("http://{0}:8080/hello", "From WPF5");
            AddDetails(details, stopwatch);
        }

        private void OnSayHelloSoap(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            DetailObject details = RunClient.Execute("http://{0}:5050/Service.svc", "From WPF5 SoapCore");
            AddDetails(details, stopwatch);
        }

        private void AddDetails(DetailObject obj,
                                Stopwatch stopwatch)
        {
            stopwatch.Stop();
            int time = (int)stopwatch.ElapsedMilliseconds;
            DetailModel model = new DetailModel
            {
                NameString = obj.NameString,
                HelloString = obj.HelloString,
                FromString = obj.FromString,
                Count = obj.Count,
                Time = time
            };

            MainViewModel viewModel = (MainViewModel)DataContext;
            viewModel.Models.Add(model);
            TheGrid.ItemsSource = viewModel.Models;
        }
    }
}