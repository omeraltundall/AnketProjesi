using AnketFinal.Model;
using AnketFinal.ViewModel;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace AnketFinal.View;

public partial class QuestionsPage2 : ContentPage
{

    public QuestionsPage2(QuestionsViewModel questionsViewModel)
    {
        InitializeComponent();
        BindingContext = questionsViewModel;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        List<Data> answer = new List<Data>();
        Data answer1 = new();
        Data answer2 = new();
        Data answer3 = new();
        
        answer1.AnketName=Title; answer2.AnketName=Title;answer3.AnketName=Title;
        answer1.Root=que1.Text;answer2.Root=que2.Text;answer3.Root=que3.Text; 
        
        if(RadioButtonA.IsChecked)
            answer1.Answer=RadioButtonA.Content.ToString();
        else if(RadioButtonB.IsChecked)
            answer1.Answer=RadioButtonB.Content.ToString();
        else if(RadioButtonC.IsChecked)
            answer1.Answer= RadioButtonC.Content.ToString();


        if (RadioButtonD.IsChecked)
            answer2.Answer = RadioButtonD.Content.ToString();
        else if (RadioButtonE.IsChecked)
            answer2.Answer = RadioButtonE.Content.ToString();
        else if (RadioButtonF.IsChecked)
            answer2.Answer = RadioButtonF.Content.ToString();

        if (RadioButtonG.IsChecked)
            answer3.Answer = RadioButtonG.Content.ToString();
        else if (RadioButtonH.IsChecked)
            answer3.Answer = RadioButtonH.Content.ToString();
        else if (RadioButtonj.IsChecked)
            answer3.Answer = RadioButtonj.Content.ToString();

        if (answer1.Answer != null && answer2.Answer != null && answer3.Answer != null)
        {
            answer.Add(answer1);
            answer.Add(answer2);
            answer.Add(answer3);
            
            string filepath = "D:\\kayýt\\cevaplar.txt";

            //Türkçe karakterler ayarý
            var encoderSettings = new TextEncoderSettings();
            encoderSettings.AllowCharacters('\u0436', '\u0430', '\u00D6', '\u00C7', '\u0131', '\u00DC', '\u00F6', '\u00E7', '\u00FC', '\u0131', '\u011F', '\u015F', '\u015E', '\u0130');
            encoderSettings.AllowRange(UnicodeRanges.BasicLatin);
            var options1 = new JsonSerializerOptions
            {

                Encoder = JavaScriptEncoder.Create(encoderSettings),

                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(answer, options1);

            //File.WriteAllText(filepath, json);

            File.AppendAllText(filepath, json);

            DisplayAlert("alert", "your answers have been colected. Thank you", "ok");





        }
        else
        {
            DisplayAlert("alert", "please answer all questions", "ok");



        }




    }
}