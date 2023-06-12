using AnketFinal.ViewModel;

namespace AnketFinal.View;

public partial class QuestionsPage : ContentPage
{	
	
	public QuestionsPage(QuestionsViewModel questionsViewModel)
	{
		InitializeComponent();
		BindingContext = questionsViewModel;
	}
}