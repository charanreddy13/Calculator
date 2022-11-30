using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Calculator.Model;
using Calculator.service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Calculator.ModelView
{
    public partial class HistoryViewModel : ObservableObject
    {
        private readonly IexpressionService _expressionservice;
        public HistoryViewModel(IexpressionService expressionservice)
        {
            _expressionservice = expressionservice;
        }


        public ObservableCollection<Model.Expression> ExpressionsList { get; set; } = new ObservableCollection<Model.Expression>();

        [ObservableProperty]
        string expression;

        [ObservableProperty]
        int result;
        [RelayCommand]
        public async void GetExpressions()
        {

            var expressionList = await _expressionservice.GetExpressions();
            if (expressionList?.Count > 0)
            {
                ExpressionsList.Clear();
                foreach (var expression in expressionList)
                {
                    ExpressionsList.Add(expression);
                }

            }
        }



        [RelayCommand]
        public async void Add()
        {
            await _expressionservice.AddExpression(new Model.Expression
            {
                expression = expression,
                result = result
            });
        }
        [RelayCommand]
        public async void Delete()
        {
            foreach (var exp in ExpressionsList)
            {
                await _expressionservice.DeleteExpression(exp);
            }
            ExpressionsList.Clear();
        }
    }
}
