using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Base class for converter panels. Inherits from Monobehaviour and 
/// has fields for the user input as well as the Converter. Also contains
/// the button click for the conversion.
/// </summary>
public class ConverterPanel : MonoBehaviour
{
    public InputField userInputField;
    public event EventHandler<ResultModel> Converted;
    protected Converter _converter;
    protected int conversionSelection = 0;

    /// <summary>
    /// Raises the Converted event and passes the ResultModel to subscribers.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="newResult"></param>
    protected virtual void OnNewResult(object sender, ResultModel newResult)
    {
        Converted?.Invoke(this, newResult);
    }

    /// <summary>
    /// Button click to start converting the user input.
    /// </summary>
    public virtual void OnClick_Convert()
    {
        _converter.Convert(userInputField.text, conversionSelection);
    }

    /// <summary>
    /// Sets the selection for the type of conversion. Defaults to 0.
    /// </summary>
    public virtual void OnClick_ConversionSelectionOne()
    {
        conversionSelection = 1;
    }

    /// <summary>
    /// Sets the selection for the type of conversion. Defaults to 0.
    /// </summary>
    public virtual void OnClick_ConversionSelectionZero()
    {
        conversionSelection = 0;
    }
}
