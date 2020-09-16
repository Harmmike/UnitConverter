using System;
using System.Linq;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    public GameObject converterPanel;
    public GameObject[] conversionPanels;

    public event EventHandler<ResultModel> NewResult;
    public event EventHandler TabOpened;

    public void OnClick_OpenTempConverter()
    {
        CloseOpenPanel();
        GameObject tempPanel = conversionPanels.FirstOrDefault(p => p.GetComponent<TempConverterPanel>());
        var converter = Instantiate(tempPanel, converterPanel.transform).GetComponent<TempConverterPanel>();
        converter.Converted += OnConverted;
    }

    public void OnClick_OpenWeightConverter()
    {
        CloseOpenPanel();
        GameObject tempPanel = conversionPanels.FirstOrDefault(p => p.GetComponent<WeightConverterPanel>());
        var converter = Instantiate(tempPanel, converterPanel.transform).GetComponent<WeightConverterPanel>();
        converter.Converted += OnConverted;
    }

    public void OnClick_OpenLengthConverter()
    {
        CloseOpenPanel();
        GameObject tempPanel = conversionPanels.FirstOrDefault(p => p.GetComponent<LengthConverterPanel>());
        var converter = Instantiate(tempPanel, converterPanel.transform).GetComponent<LengthConverterPanel>();
        converter.Converted += OnConverted;
    }

    public void OnClick_OpenCurrencyConverter()
    {
        CloseOpenPanel();
        GameObject tempPanel = conversionPanels.FirstOrDefault(p => p.GetComponent<CurrencyConverterPanel>());
        var converter = Instantiate(tempPanel, converterPanel.transform).GetComponent<CurrencyConverterPanel>();
        converter.Converted += OnConverted;
    }

    private void CloseOpenPanel()
    {
        var openPanel = converterPanel.GetComponentInChildren<ConverterPanel>();
        if (openPanel != null)
        {
            openPanel.Converted -= OnConverted;
            Destroy(openPanel.gameObject);
        }
        else { return; }

        TabOpened?.Invoke(this, new EventArgs());
    }

    private void OnConverted(object sender, ResultModel result)
    {
        NewResult?.Invoke(this, result);
    }
}
