public class TempConverterPanel : ConverterPanel
{
    private void Start()
    {
        _converter = new Converter(Converter.ConverterCategory.Temperature);
        _converter.NewResult += OnNewResult;
    }

    public virtual void OnClick_ConvertTemperature()
    {
        _converter.Convert(userInputField.text);
    }
}
