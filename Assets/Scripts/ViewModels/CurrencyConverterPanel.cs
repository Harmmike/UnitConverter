using UnityEngine.UI;
/// <summary>
/// Class for the Currency Panel. Inherits from ConverterPanel and adds 
/// initialization for the Converter.
/// </summary>
public class CurrencyConverterPanel : ConverterPanel
{
    private void Start()
    {
        _converter = new Converter(Converter.ConverterCategory.Currency);
        _converter.NewResult += OnNewResult;
    }

    public override void OnClick_ConversionSelectionZero()
    {
        base.OnClick_ConversionSelectionZero();
        userInputField.placeholder.GetComponent<Text>().text = "USD";
    }

    public override void OnClick_ConversionSelectionOne()
    {
        base.OnClick_ConversionSelectionOne();
        userInputField.placeholder.GetComponent<Text>().text = "RMB";
    }
}
