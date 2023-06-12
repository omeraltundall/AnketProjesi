using AnketFinal.Model;
using AnketFinal.Services;
using AnketFinal.View;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AnketFinal.ViewModel;

public partial class AnketsViewModel : BaseViewModel
{
    AnketService anketService;
    public ObservableCollection<Root> Results { get; } = new();
    public AnketsViewModel(AnketService anketService)
    {
        Title = "Anketler";
        this.anketService = anketService;
    }


    [RelayCommand]
    async Task GoToQuestions(Root root)
    {
        if (root == null)
        {
            return;
        }
            await Shell.Current.GoToAsync(nameof(QuestionsPage), true, new Dictionary<string, object>
        {
            {"Root",root}
        });
        
    }

    [RelayCommand]
    async Task GoToQuestions2(Root root)
    {
        if (root == null)
        {
            return;
        }
        await Shell.Current.GoToAsync(nameof(QuestionsPage2), true, new Dictionary<string, object>
        {
            {"Root",root}
        });

    }

    [RelayCommand]
    async Task GetAnketsAsync()
    {
        if(IsBusy) return;
        try
        {   
            IsBusy = true;
            var ankets = await anketService.GetAnkets();

            //if (Results.Count != 0)
            //    Results.Clear();

            Results?.Clear();

            //foreach (var anket in ankets)
            //{
            //    Results.Add(anket);
            //}

            
            Results.Add(ankets);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error",
                $"Unable to get questions: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}