using Assets.Scripts.Data;
using System;
using UnityEngine;

/// <summary>
/// Class for performing conversions according to the type of converter selected.
/// </summary>
public class Converter
{
    public enum ConverterCategory
    {
        Temperature,
        Weight,
        Length,
        Currency
    }

    private int conversionSelection = 0;
    public ConverterCategory ConverterType;
    public EventHandler<ResultModel> NewResult;
    
    public Converter(ConverterCategory category)
    {
        ConverterType = category;
    }

    /// <summary>
    /// Converts the input value to the designated type.
    /// </summary>
    /// <param name="input"></param>
    public void Convert(string input, int selection = 0)
    {
        conversionSelection = selection;
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

    /// <summary>
    /// Calculates the input according the type of converter selected.
    /// </summary>
    /// <param name="inputValue"></param>
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

    /// <summary>
    /// Gets the current exchange rate of USD and RMB and converts according to the selection given.
    /// </summary>
    /// <param name="inputValue"></param>
    private async void GetExchangeResult(double inputValue)
    {
        ExchangeSystem eSystem = new ExchangeSystem();
        ExchangeRate eRate = await eSystem.GetExchangeRate();

        if (conversionSelection == 1)
        {
            double newUSD = Math.Round((eRate.rates.USD / eRate.rates.CNY) * inputValue, 3);
            double newCNY = Math.Round((eRate.rates.CNY / eRate.rates.CNY) * inputValue, 3);
            string result = $"{newCNY}RMB : {newUSD}USD";
            NewResult?.Invoke(this, new ResultModel(result));
        }
        else if(conversionSelection == 0)
        {
            double newUSD = Math.Round((eRate.rates.USD / eRate.rates.USD) * inputValue, 3);
            double newCNY = Math.Round((eRate.rates.CNY / eRate.rates.USD) * inputValue, 3);
            string result = $"{newUSD}USD : {newCNY}RMB";
            NewResult?.Invoke(this, new ResultModel(result));
        }
        else { return; }
    }

    /// <summary>
    /// Gets the converted length according to the selected conversion.
    /// </summary>
    /// <param name="inputValue"></param>
    private void GetLengthResult(double inputValue)
    {
        if(conversionSelection == 1)
        {
            string cm = $"{Math.Round(inputValue * 2.54, 3)}cm.";
            NewResult?.Invoke(this, new ResultModel(cm));
        }
        else if(conversionSelection == 0)
        {
            string inches = $"{Math.Round(inputValue * 0.3937007874, 3)}in.";
            NewResult?.Invoke(this, new ResultModel(inches));
        }
        else { return; }
    }

    /// <summary>
    /// Gets the converted weight from kg to lbs or lbs to kg according to the selection.
    /// </summary>
    /// <param name="inputValue"></param>
    private void GetWeightResult(double inputValue)
    {
        if(conversionSelection == 1)
        {
            string kg = $"{Math.Round(inputValue * 0.45359237),2}kg.";
            NewResult?.Invoke(this, new ResultModel(kg));
        }
        else if(conversionSelection == 0)
        {
            string pounds = $"{Math.Round(inputValue * 2.20462262185, 2)}lb.";
            NewResult?.Invoke(this, new ResultModel(pounds));
        }
        else { return; }
    }

    /// <summary>
    /// Gets the converted temperature from Celsius to Fahrenheit or
    /// Fahrenheit to Celsius according to the selection.
    /// </summary>
    /// <param name="inputValue"></param>
    private void GetTempResult(double inputValue)
    {
        if(conversionSelection == 1)
        {
            string celsius = $"{Math.Round((inputValue - 32) / 1.8, 3)}°C";
            NewResult?.Invoke(this, new ResultModel(celsius));
        }
        else if(conversionSelection == 0)
        {
            string fahrenheit = $"{Math.Round((inputValue * 1.8) + 32, 3)}°F";
            NewResult?.Invoke(this, new ResultModel(fahrenheit));
        }
        else { return; }
    }
}
