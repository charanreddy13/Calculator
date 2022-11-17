using Calculator.ModelView;

namespace Calculator.Pages;

public partial class History : ContentPage
{
	public History(Historyviewmodel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}