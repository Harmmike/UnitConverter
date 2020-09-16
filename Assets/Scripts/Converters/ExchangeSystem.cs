using Assets.Scripts.Data;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;

public class ExchangeSystem
{
    private const string url = "https://api.exchangeratesapi.io/latest?symbols=USD,CNY";
   
    public async Task<ExchangeRate> GetExchangeRate()
    {
		try
		{
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(url));
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            StreamReader sReader = new StreamReader(response.GetResponseStream());
            string jsonResponse = sReader.ReadToEnd();
            ExchangeRate info = JsonUtility.FromJson<ExchangeRate>(jsonResponse);
            return info;
        }
		catch (Exception e)
		{
            Debug.Log(e.Message);
            return null;
        }
    }
}
