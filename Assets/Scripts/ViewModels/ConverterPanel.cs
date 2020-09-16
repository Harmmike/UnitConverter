using System;
using UnityEngine;
using UnityEngine.UI;

public class ConverterPanel : MonoBehaviour
{
    public InputField userInputField;
    public event EventHandler<ResultModel> Converted;
    protected Converter _converter;

    protected virtual void OnNewResult(object sender, ResultModel newResult)
    {
        Converted?.Invoke(this, newResult);
    }
}
