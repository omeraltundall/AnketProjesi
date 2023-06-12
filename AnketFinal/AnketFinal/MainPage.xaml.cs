using AnketFinal.ViewModel;
namespace AnketFinal;

public partial class MainPage : ContentPage
{
    public MainPage(AnketsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;

    }
}

