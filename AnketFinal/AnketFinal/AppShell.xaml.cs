using AnketFinal.View;
namespace AnketFinal;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(QuestionsPage2), typeof(QuestionsPage2));
        Routing.RegisterRoute(nameof(QuestionsPage), typeof(QuestionsPage));
    }
}
