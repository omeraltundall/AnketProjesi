using AnketFinal.ViewModel;

namespace AnketFinal.View;

public partial class QuestionsPage2 : ContentPage
{

    public QuestionsPage2(QuestionsViewModel questionsViewModel)
    {
        InitializeComponent();
        BindingContext = questionsViewModel;
    }
}