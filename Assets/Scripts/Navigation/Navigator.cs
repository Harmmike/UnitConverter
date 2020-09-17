using System;
using System.Linq;
using UnitConverter.Logging.Logging;
using UnityEngine;

/// <summary>
/// Main class for Unit Converter application. Contains controls for navigation buttons
/// as well as the Event being fired for displaying results. Inherits from Monobehaviour and 
/// must be attached to a game object.
/// </summary>
public class Navigator : MonoBehaviour
{
    [Header("Parent for Converter Panels")]
    /// <summary>
    /// The parent panel for ConverterPanel instantiation. This should have no children objects.
    /// </summary>
    public GameObject converterPanel;

    [Header("Converter Panel Prefabs")]
    /// <summary>
    /// Array of ConverterPanel prefabs. When new panels are created, they MUST be added here.
    /// </summary>
    public GameObject[] conversionPanels;

    public event EventHandler<ResultModel> NewResult;
    public event EventHandler TabOpened;

    #region Button Clicks
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
    #endregion

    /// <summary>
    /// Closes the current open panel by destroying the gameObject.
    /// This also unsubscribes from the OnConverted event to prevent
    /// erroneous events and prepare for garbage collection.
    /// </summary>
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

    /// <summary>
    /// Raises the Converted event to notify the ResultPanel that a new
    /// result is available to display.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="result"></param>
    private void OnConverted(object sender, ResultModel result)
    {
        NewResult?.Invoke(this, result);
    }
}
