using System.Text.Encodings.Web;
using System.Text.Json;
using AnketFinal.Model;
using System.Text.Unicode;
using AnketFinal.ViewModel;
using Microsoft.Maui.Controls.PlatformConfiguration;


using static Android.Provider.Settings;
namespace AnketFinal.View;

public partial class QuestionsPage : ContentPage
{

    private HashSet<string> filledSurveyIds = new HashSet<string>();
    public QuestionsPage(QuestionsViewModel questionsViewModel)
    {
        InitializeComponent();
        BindingContext = questionsViewModel;
    }
    public async void ClickSubmit(object sender, EventArgs e)
    {

        IGetDeviceInfo getDeviceInfo = new GetDeviceInfo();
        var id = getDeviceInfo.GetDeviceID();

        if (IsSurveyFilled(id))
        {
            DisplayAlert("Alert", "You already filled this survey before.", "ok");
        }
        else
        {
            List<Data> answer = new List<Data>();
            Data answer1 = new();
            Data answer2 = new();
            Data answer3 = new();
            Data answer4 = new();

            

            answer1.Root = que1.Text; answer2.Root = que2.Text; answer3.Root = que3.Text; answer4.Root = que4.Text;
            answer1.AnketName = Title; answer2.AnketName = Title; answer3.AnketName = Title; answer4.AnketName = Title;

            if (RadioButtonA.IsChecked)
                answer1.Answer = RadioButtonA.Content.ToString();
            else if (RadioButtonB.IsChecked)
                answer1.Answer = RadioButtonB.Content.ToString();

            if (RadioButtonC.IsChecked)
                answer2.Answer = RadioButtonC.Content.ToString();
            else if (RadioButtonD.IsChecked)
                answer2.Answer = RadioButtonD.Content.ToString();

            if (RadioButtonE.IsChecked)
                answer3.Answer = RadioButtonE.Content.ToString();
            else if (RadioButtonF.IsChecked)
                answer3.Answer = RadioButtonF.Content.ToString();

            if (RadioButtonG.IsChecked)
                answer4.Answer = RadioButtonG.Content.ToString();
            else if (RadioButtonH.IsChecked)
                answer4.Answer = RadioButtonH.Content.ToString();

            if (answer1.Answer != null && answer2.Answer != null && answer3.Answer != null && answer4.Answer != null)
            {

                answer.Add(answer1);
                answer.Add(answer2);
                answer.Add(answer3);
                answer.Add(answer4);
                //Buraya kendi pcnde bir dosya seç txt dosyasını oluşturmana gerek yok
                //string filepath = "D:\\kayýt\\cevaplar.txt";

                //Türkçe karakterler ayarı
                var encoderSettings = new TextEncoderSettings();
                encoderSettings.AllowCharacters('\u0436', '\u0430', '\u00D6', '\u00C7', '\u0131', '\u00DC', '\u00F6', '\u00E7', '\u00FC', '\u0131', '\u011F', '\u015F', '\u015E');
                encoderSettings.AllowRange(UnicodeRanges.BasicLatin);
                var options1 = new JsonSerializerOptions
                {

                    Encoder = JavaScriptEncoder.Create(encoderSettings),

                    WriteIndented = true
                };
                string json = JsonSerializer.Serialize(answer, options1);

                //File.WriteAllText(filepath, json);

               // File.AppendAllText(filepath, json);
                DisplayAlert("Alert", "Your answers have been colected. Thank you", "Ok");
                AddFilledSurveyId(id);
            }
            else
            {
                DisplayAlert("Alert", "Please answer all questions", "Ok");
            }
           
        }

    }
    public void AddFilledSurveyId(string id)
    {
        filledSurveyIds.Add(id);
    }
    public bool IsSurveyFilled(string surveyId)
    {
        return filledSurveyIds.Contains(surveyId);
    }

    public interface IGetDeviceInfo { string GetDeviceID(); }
    internal class GetDeviceInfo : IGetDeviceInfo
    {
        public string GetDeviceID()
        {

            var context = Android.App.Application.Context;

            string id = Android.Provider.Settings.Secure.GetString(context.ContentResolver, Secure.AndroidId);

            return id;
        }
    }


}