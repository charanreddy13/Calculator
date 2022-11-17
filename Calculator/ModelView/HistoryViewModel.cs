using System.Collections.ObjectModel;
using Calculator.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Calculator.ModelView
{
    public  partial class HistoryViewModel: ObservableObject
    {
        public HistoryViewModel()
        {
            expressions = new ObservableCollection<string>();
            results = new ObservableCollection<int>();

        }
        [ObservableProperty]
        ObservableCollection<string> expressions;

        [ObservableProperty]
        ObservableCollection<int> results;

        [ObservableProperty]
        string expression;

        [ObservableProperty]
        int result;
    }
}
