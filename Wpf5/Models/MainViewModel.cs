using System.Collections.ObjectModel;
using Wcf5.Shared.ClientModels;

namespace Wpf5.Models
{
    public class MainViewModel
    {
        public ObservableCollection<DetailModel> Models { get; set; }
    }
}