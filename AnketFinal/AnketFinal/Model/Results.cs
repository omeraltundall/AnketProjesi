namespace AnketFinal.Model;

public class Answers
{
    public string answer1 { get; set; }
    public string answer2 { get; set; }
    public string answer3 { get; set; }
}

public class Questions
{
    public string que1 { get; set; }
    public string que2 { get; set; }
    public string que3 { get; set; }
    public string que4 { get; set; }
}

public class Result
{
    public string AnketName { get; set; }
    public Questions Questions { get; set; }
    public Answers Answers { get; set; }
    public int NoOfQue { get; set; }
}

public class Root
{
    public List<Result> Results { get; set; }
}

public class Data
{
    public string AnketName { get; set; }

    public string Root { get; set; }

    public string Answer { get; set; }

}