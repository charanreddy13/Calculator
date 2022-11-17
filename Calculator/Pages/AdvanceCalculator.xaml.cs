using Calculator.ModelView;

namespace Calculator.Pages;

public partial class AdvanceCalculator : ContentPage
{
	public AdvanceCalculator(HistoryViewModel his)
	{
		InitializeComponent();
        OnClear(this, null);
        BindingContext = his;
    }
    string currentEntry = "";
    int currentState = 1;
    string mathOperator;
    double firstNumber, secondNumber;
    string decimalFormat = "N0";
    Boolean IsparnthesisOpen = false;



    void OnSelectNumber(object sender, EventArgs e)
    {

        Button button = (Button)sender;
        string pressed = button.Text;

        currentEntry += pressed;

        if ((this.resultText.Text == "0" && pressed == "0")
            || (currentEntry.Length <= 1 && pressed != "0")
            || currentState < 0)
        {
            this.resultText.Text = "";
            if (currentState < 0)
                currentState *= -1;
        }

        if (pressed == "." && decimalFormat != "N2")
        {
            decimalFormat = "N2";
        }

        this.resultText.Text += pressed;
        this.CurrentCalculation.Text += pressed;
    }
    void onSquareRoot(object sender, EventArgs e)
    {
        if (currentState == 1)
        {

            double.TryParse(currentEntry, out firstNumber);
            firstNumber = System.Math.Sqrt(firstNumber);
            this.resultText.Text = firstNumber.ToString();
        }
    }
    void onBrackets(object sender, EventArgs e)
    {
        if (IsparnthesisOpen)
        {
            LockNumberValue(resultText.Text);
            this.resultText.Text = ")";
            this.CurrentCalculation.Text += ")";
            IsparnthesisOpen = false;

        }
        else
        {
            LockNumberValue(resultText.Text);
            this.resultText.Text = "(";
            this.CurrentCalculation.Text += "(";
            currentState = -2;
            IsparnthesisOpen = true;
        }
        if (IsparnthesisOpen == false)
        {

            mathOperator = "×";

        }
    }
    void OnSelectOperator(object sender, EventArgs e)
    {
        if (currentState == 2)
        {
            LockNumberValue(resultText.Text);
            double result = Calculator.Calculate(firstNumber, secondNumber, mathOperator);

            //this.CurrentCalculation.Text = $"{firstNumber} {mathOperator} {secondNumber}";

            this.resultText.Text = result.ToTrimmedString(decimalFormat);
            firstNumber = result;
            secondNumber = 0;
            currentState = -1;
            currentEntry = string.Empty;
            CurrentCalculation.Text = "";

        }
        else
        {
            LockNumberValue(resultText.Text);
        }
        currentState = -2;
        Button button = (Button)sender;
        string pressed = button.Text;
        mathOperator = pressed;
        this.CurrentCalculation.Text += pressed;
    }

    private void LockNumberValue(string text)
    {
        double number;
        if (double.TryParse(text, out number))
        {
            if (currentState == 1)
            {
                firstNumber = number;
            }
            else
            {
                secondNumber = number;
            }

            currentEntry = string.Empty;
        }
    }

    void OnClear(object sender, EventArgs e)
    {
        firstNumber = 0;
        secondNumber = 0;
        currentState = 1;
        IsparnthesisOpen = false;
        decimalFormat = "N0";
        this.resultText.Text = "0";
        this.currentEntry = string.Empty;
        this.CurrentCalculation.Text = "";
    }

    void OnCalculate(object sender, EventArgs e)
    {
        if (currentState == 2)
        {
            if (IsparnthesisOpen == false)
            {
                if (secondNumber == 0)
                    LockNumberValue(resultText.Text);

                double result = Calculator.Calculate(firstNumber, secondNumber, mathOperator);

                //this.CurrentCalculation.Text = $"{firstNumber} {mathOperator} {secondNumber}";

                this.resultText.Text = result.ToTrimmedString(decimalFormat);
                firstNumber = result;
                secondNumber = 0;
                currentState = -1;
                currentEntry = string.Empty;
            }
        }
    }


    void OnNegative(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            secondNumber = -1;
            mathOperator = "×";
            currentState = 2;
            OnCalculate(this, null);
        }
    }

    void OnPercentage(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            LockNumberValue(resultText.Text);
            decimalFormat = "N2";
            secondNumber = 0.01;
            mathOperator = "×";
            currentState = 2;
            OnCalculate(this, null);
        }
    }
}