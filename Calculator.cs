namespace Calculator;

using System;

public class Calculator
{
    public enum Operation
    {
        Add,
        Subtract,
        Multiply,
        Divide,
        None
    }

    public event Action? OnNumChanged;

    private double num = 0;
    private double Num
    {
        get => num;

        set
        {
            num = value;
            shouldReset = false;
            OnNumChanged?.Invoke();
        }
    }
    public string NumStr
    {
        get
        {
            //Round num to deal with floating point errors
            string numStr = Math.Round(Num, 10).ToString();

            if(decimalPlace == 1)
            {
                return numStr + '.';
            }
            else
            {
                return numStr;
            }
        }
    }
    private double prevNum = 0;
    private Operation operation = Operation.None;
    private bool shouldReset = true;
    private int decimalPlace = 0;

    public void AddDigit(int digit)
    {
        if(shouldReset)
        {
            Clear();
        }

        if(decimalPlace == 0)
        {
            Num = (Num * 10) + digit;
        }
        else
        {
            Num += digit / Math.Pow(10, decimalPlace++);
        }
    }

    public void Clear()
    {
        Num = 0;
        prevNum = 0;

        decimalPlace = 0;

        shouldReset = false;
    }

    public void SetOperation(Operation op)
    {
        operation = op;

        prevNum = Num;
        Num = 0;
        decimalPlace = 0;
    }

    public void Negate()
    {
        Num *= -1;
    }

    public void AddDecimal()
    {
        if(decimalPlace != 0)
        {
            return;
        }

        decimalPlace = 1;
        OnNumChanged?.Invoke();
    }

    public void Sqr()
    {
        Num *= Num;
        shouldReset = true;
    }
    public void Sqrt()
    {
        Num = Math.Sqrt(Num);
        shouldReset = true;
    }

    public void Calculate()
    {
        switch(operation)
        {
            case Operation.None:
                return;

            case Operation.Add:
                Num = prevNum + Num;
                break;

            case Operation.Subtract:
                Num = prevNum - Num;
                break;

            case Operation.Multiply:
                Num = prevNum * Num;
                break;

            case Operation.Divide:
                Num = prevNum / Num;
                break;
        }
        shouldReset = true;
    }
}