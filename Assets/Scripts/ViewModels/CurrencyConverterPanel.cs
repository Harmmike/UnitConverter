using UnityEngine;

public class CurrencyConverterPanel : ConverterPanel
{
    private void Start()
    {
        _converter = new Converter(Converter.ConverterCategory.Currency);
        _converter.NewResult += OnNewResult;
    }

    public void OnClick_ConvertCurrency()
    {
        _converter.Convert(userInputField.text);
    }
}
