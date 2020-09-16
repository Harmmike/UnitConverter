using Assets.Scripts.Data;
using System;
using System.Threading.Tasks;

public class Converter
{
    public enum ConverterCategory
    {
        Temperature,
        Weight,
        Length,
        Currency
    }

    public ConverterCategory ConverterType;
    public EventHandler<ResultModel> NewResult;

    public Converter(ConverterCategory category)
    {
        ConverterType = category;
    }

    public void Convert(string input)
    {
        double inputValue = 0;
        try
        {
            inputValue = double.Parse(input);
        }
        catch (System.Exception)
        {
            return;
        }
        Calculate(inputValue);
    }

    protected virtual void Calculate(double inputValue)
    {
        switch (ConverterType)
        {
            case ConverterCategory.Temperature:
                GetTempResult(inputValue);
                break;

            case ConverterCategory.Weight:
                GetWeightResult(inputValue);
                break;

            case ConverterCategory.Length:
                GetLengthResult(inputValue);
                break;

            case ConverterCategory.Currency:
                GetExchangeResult(inputValue);
                break;
        }
    }

    private async void GetExchangeResult(double inputValue)
    {
        ExchangeSystem eSystem = new ExchangeSystem();
        ExchangeRate eRate = await eSystem.GetExchangeRate();
        double newUSD = Math.Round((eRate.rates.USD / eRate.rates.USD) * inputValue, 3);
        double newCNY = Math.Round((eRate.rates.CNY / eRate.rates.USD) * inputValue, 3);
        string result = $"{newUSD}USD : {newCNY}RMB";
        NewResult?.Invoke(this, new ResultModel(result));
    }

    private void GetLengthResult(double inputValue)
    {
        string inches = $"{Math.Round(inputValue * 0.3937007874, 3)}in.";
        NewResult?.Invoke(this, new ResultModel(inches));
    }

    private void GetWeightResult(double inputValue)
    {
        string pounds = $"{Math.Round(inputValue * 2.20462262185, 2)}lb.";
        NewResult?.Invoke(this, new ResultModel(pounds));
    }

    private void GetTempResult(double inputValue)
    {
        string fahrenheit = $"{Math.Round((inputValue * 1.8) + 32, 3)}°F";
        NewResult?.Invoke(this, new ResultModel(fahrenheit));
    }
}
