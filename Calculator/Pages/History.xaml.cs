using Calculator.ModelView;

namespace Calculator.Pages;

public partial class History : ContentPage
{
	public History(HistoryViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}