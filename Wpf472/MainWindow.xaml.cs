
using Shared.Client;
using Shared.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

namespace Wpf472
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainModel viewModel = new MainModel
            {
                Models = new ObservableCollection<DetailModel472>()
            };
            DataContext = (MainModel)viewModel;
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            MainModel viewModel = (MainModel)DataContext;
            TheGrid.ItemsSource = viewModel.Models;
        }

        private void OnSayHello(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            ServiceReference1.HelloWorldServiceClient client = new ServiceReference1.HelloWorldServiceClient();

            string result = client.SayHello("From Wpf");
            DetailObject details = client.GetDetailObject("From WPF");
            client.Close();

            AddDetails(details, stopwatch);
        }

        private void OnSayHelloBind(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            DetailObject details = RunClient.Execute("http://{0}:8080/hello", "From WPF");
            AddDetails(details, stopwatch);
        }

        private void OnSayHelloSoap(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            DetailObject details = RunClient.Execute("http://{0}:5050/Service.svc", "From WPF");
            AddDetails(details, stopwatch);
        }

        private void AddDetails(DetailObject obj,
                                Stopwatch stopwatch)
        {
            stopwatch.Stop();
            int time = (int)stopwatch.ElapsedMilliseconds;
            DetailModel472 model = new DetailModel472
            {
                NameString = obj.NameString,
                HelloString = obj.HelloString,
                FromString = obj.FromString,
                Count = obj.Count,
                Time = time
            };

            MainModel viewModel = (MainModel)DataContext;
            viewModel.Models.Add(model);
            TheGrid.ItemsSource = viewModel.Models;
        }
    }
}