using UnityEngine.UI;
/// <summary>
/// Class for the Weight Panel. Inherits from ConverterPanel and adds 
/// initialization for the Converter.
/// </summary>
public class WeightConverterPanel : ConverterPanel
{
    private void Start()
    {
        _converter = new Converter(Converter.ConverterCategory.Weight);
        _converter.NewResult += OnNewResult;
    }

    public override void OnClick_ConversionSelectionZero()
    {
        base.OnClick_ConversionSelectionZero();
        userInputField.placeholder.GetComponent<Text>().text = "Kg";
    }

    public override void OnClick_ConversionSelectionOne()
    {
        base.OnClick_ConversionSelectionOne();
        userInputField.placeholder.GetComponent<Text>().text = "Lbs";
    }
}
