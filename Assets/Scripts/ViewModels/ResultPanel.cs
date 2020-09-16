using System;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    public Text resultTextBox;

    private void Start()
    {
        var navigator = FindObjectOfType<Navigator>();
        navigator.NewResult += OnNewResult;
        navigator.TabOpened += OnTabOpened;
    }

    private void OnNewResult(object sender, ResultModel newResult)
    {
        resultTextBox.text = newResult.Result;
    }

    private void OnTabOpened(object sender, EventArgs e)
    {
        resultTextBox.text = "Waiting...";
    }
}
