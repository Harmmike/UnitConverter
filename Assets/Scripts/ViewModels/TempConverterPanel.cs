using UnityEngine.UI;
/// <summary>
/// Class for the Temperature Panel. Inherits from ConverterPanel and adds 
/// initialization for the Converter.
/// </summary>
public class TempConverterPanel : ConverterPanel
{
    private void Start()
    {
        _converter = new Converter(Converter.ConverterCategory.Temperature);
        _converter.NewResult += OnNewResult;
    }

    public override void OnClick_ConversionSelectionZero()
    {
        base.OnClick_ConversionSelectionZero();
        userInputField.placeholder.GetComponent<Text>().text = "°C";
    }

    public override void OnClick_ConversionSelectionOne()
    {
        base.OnClick_ConversionSelectionOne();
        userInputField.placeholder.GetComponent<Text>().text = "°F";
    }
}
