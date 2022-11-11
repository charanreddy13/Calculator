using Calculator.Model;
using System.Net.Http.Json;

namespace Calculator.Pages;

public partial class Exercise : ContentPage
{
	public Exercise()
	{
		InitializeComponent();
        GetValuesAsync();
    }
    
    public static readonly string baseUrl = "https://localhost:44308/questions";
     List<Questions>questionList = new List<Questions>();
    public async Task<List<Questions>> GetValuesAsync()
    {
        
        HttpClient client=new HttpClient();
        string url=baseUrl;
        client.BaseAddress = new Uri(url);
        HttpResponseMessage responseMessage = await client.GetAsync("");
        if(responseMessage.IsSuccessStatusCode)
        {
            questionList = await responseMessage.Content.ReadFromJsonAsync<List<Questions>>();
            getvalues();
        }
        return await Task.FromResult(questionList);
    }

    int[] number1 = new int[10];
    int[] numbe2 = new int[10];
    string[] operatorr = new String[10];
    int[] random1 = new int[10];
    int[] random2 = new int[10];
    int[] random3 = new int[10];
    int i = 0;
    int score = 0;
    void getvalues()
    {
        for(int j=0; j<number1.Length; j++)
        {
            Questions question = new Questions();
            question=questionList[j];
            number1[j] = question.operand1;
            numbe2[j] = question.operand2;
            operatorr[j] = question.oper;
            random1[j] = question.answer;
            random2[j] = question.randanswer2;
            random3[j] = question.randanswer1;

        }
        assign(this, null);
    }

    void assign(object sender, EventArgs e)
    {
        if (i <= 9)
        {
            String question = number1[i] + operatorr[i] + numbe2[i];
            Heading.Text = question;
            Random rnd = new Random();
            int ope = rnd.Next(0, 3);
            switch (ope)
            {
                case 0:
                    option1.Text = random1[i].ToString();
                    option2.Text = random2[i].ToString();
                    option3.Text = random3[i].ToString();
                    break;
                case 1:
                    option1.Text = random2[i].ToString();
                    option2.Text = random3[i].ToString();
                    option3.Text = random1[i].ToString();
                    break;
                case 2:
                    option1.Text = random3[i].ToString();
                    option2.Text = random1[i].ToString();
                    option3.Text = random2[i].ToString();
                    break;
            }
        }
        else
        { 
            completed(this, null);
        }


    }
    void onsubmit(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string pressed = button.Text;
        int firstNumber = number1[i];
        int secondNumber = numbe2[i];
        string mathOperator = operatorr[i];
        double result = Calculator.Calculate(firstNumber, secondNumber, mathOperator);
        int ress = ((int)result);
        string res = ress.ToString();
        if (res == pressed)
        {
            Sucessful("Correct Answer","Next Question");
            score++;
            if (i<=9)
                nextquestion();

        }
        else
        {
            Sucessful("wrong Answer Try again","Try Again");

        }
    }
    void nextquestion()
    {
        i++;
        if (i <= 9)
        {
            assign(this, null);
        }
        else
        {
            completed(this,null);
        }
    }
    public async Task Sucessful(string msg, string butn)
    {
        await DisplayAlert("", msg,butn);
    }
    void skipp(object sender, EventArgs e)
    {
        nextquestion();
    }
    void completed(object sender, EventArgs e)
    {
        Heading.Text = "completed Quiz Thank you your Score:"+score;
        option1.Text = "";
        option2.Text = "";
        option3.Text = "";
        skip.Text = "";
    }
    void startover(object sender,EventArgs e)
    {
        i = 0;
        GetValuesAsync();
        skip.Text = "SKIP";
    }
}