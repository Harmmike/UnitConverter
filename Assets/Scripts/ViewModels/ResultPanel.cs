using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class that controls the displayed result of the conversion.
/// </summary>
public class ResultPanel : MonoBehaviour
{
    public Text resultTextBox;

    private void Start()
    {
        var navigator = FindObjectOfType<Navigator>();
        navigator.NewResult += OnNewResult;
        navigator.TabOpened += OnTabOpened;
    }

    /// <summary>
    /// When called, updates the display information of the result text box.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="newResult"></param>
    private void OnNewResult(object sender, ResultModel newResult)
    {
        resultTextBox.text = newResult.Result;
    }

    /// <summary>
    /// When called, resets the result display text to default.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnTabOpened(object sender, EventArgs e)
    {
        resultTextBox.text = "Waiting...";
    }
}
