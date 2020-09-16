public class LengthConverterPanel : ConverterPanel
{
    private void Start()
    {
        _converter = new Converter(Converter.ConverterCategory.Length);
        _converter.NewResult += OnNewResult;
    }

    public void OnClick_ConvertLength()
    {
        _converter.Convert(userInputField.text);
    }
}
