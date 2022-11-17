using System.Collections.ObjectModel;
using System.Linq.Expressions;
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
    [RelayCommand]
    void Add()
    {
        expressions.Add(expression);
        results.Add(result);
        result = 0;
        expression = string.Empty;
    }
}
