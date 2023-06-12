using AnketFinal.Model;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AnketFinal.ViewModel;

[QueryProperty(nameof(Root), "Root")]

public partial class QuestionsViewModel : BaseViewModel
{
    public QuestionsViewModel()
    {

    }

    [ObservableProperty]
    Root root;
}