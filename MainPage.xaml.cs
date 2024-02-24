using System.Diagnostics;

namespace Calculator;

public partial class MainPage : ContentPage
{
    private const int MAX_DISPLAY_LENGTH = 12;

    private readonly Calculator calc = new();

    public MainPage()
    {
        InitializeComponent();

        calc.OnNumChanged += Calc_OnNumChanged;
    }

    private void Calc_OnNumChanged()
    {
        Display.Text = calc.NumStr;
    }

    private void OnNumBtnClicked(object sender, EventArgs e)
    {
        if(calc.NumStr.Length >= MAX_DISPLAY_LENGTH)
        {
            return;
        }

        Button b = (Button)sender;
        calc.AddDigit(int.Parse(b.Text));
    }
    private void OnDecimalBtnClicked(object sender, EventArgs e)
    {
        if(calc.NumStr.Length >= MAX_DISPLAY_LENGTH)
        {
            return;
        }

        calc.AddDecimal();
    }

    private void OnAddBtnClicked(object sender, EventArgs e) => calc.SetOperation(Calculator.Operation.Add);
    private void OnSubtractBtnClicked(object sender, EventArgs e) => calc.SetOperation(Calculator.Operation.Subtract);
    private void OnMultiplyBtnClicked(object sender, EventArgs e) => calc.SetOperation(Calculator.Operation.Multiply);
    private void OnDivideBtnClicked(object sender, EventArgs e) => calc.SetOperation(Calculator.Operation.Divide);
    private void OnNegateBtnClicked(object sender, EventArgs e) => calc.Negate();
    private void OnSqrBtnClicked(object sender, EventArgs e) => calc.Sqr();
    private void OnSqrtBtnClicked(object sender, EventArgs e) => calc.Sqrt();
    private void OnEqualsBtnClicked(object sender, EventArgs e) => calc.Calculate();
    private void OnClearBtnClicked(object sender, EventArgs e) => calc.Clear();
}