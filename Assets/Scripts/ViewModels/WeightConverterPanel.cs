public class WeightConverterPanel : ConverterPanel
{
    private void Start()
    {
        _converter = new Converter(Converter.ConverterCategory.Weight);
        _converter.NewResult += OnNewResult;
    }

    public virtual void OnClick_ConvertWeight()
    {
        _converter.Convert(userInputField.text);
    }
}
