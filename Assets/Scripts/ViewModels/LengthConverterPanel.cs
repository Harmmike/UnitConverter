using UnityEngine.UI;
/// <summary>
/// Class for the Length Panel. Inherits from ConverterPanel and adds 
/// initialization for the Converter.
/// </summary>
public class LengthConverterPanel : ConverterPanel
{
    private void Start()
    {
        _converter = new Converter(Converter.ConverterCategory.Length);
        _converter.NewResult += OnNewResult;
    }

    public override void OnClick_ConversionSelectionZero()
    {
        base.OnClick_ConversionSelectionZero();
        userInputField.placeholder.GetComponent<Text>().text = "cm";
    }

    public override void OnClick_ConversionSelectionOne()
    {
        base.OnClick_ConversionSelectionOne();
        userInputField.placeholder.GetComponent<Text>().text = "in";
    }
}
