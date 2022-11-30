using Calculator.ModelView;

namespace Calculator.Pages;

public partial class History : ContentPage
{
    private readonly HistoryViewModel _viewModel;
    public History(HistoryViewModel vm)
    {
        InitializeComponent();
        _viewModel = vm;
        BindingContext = vm;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetExpressionsCommand.Execute(null);
    }
}