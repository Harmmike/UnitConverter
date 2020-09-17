using Assets.Scripts.Data;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;

public class ExchangeSystem
{
    private const string url = "https://api.exchangeratesapi.io/latest?symbols=USD,CNY";
   
    /// <summary>
    /// Sends a GET request to API and returns an ExchangeRate with the current values.
    /// </summary>
    /// <returns></returns>
    public async Task<ExchangeRate> GetExchangeRate()
    {
		try
		{
            //Creates an HttpWebRequest using the url.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(url));

            //Gets a response asynchronously from the request.
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();

            //Creates a StreamReader to get the serialized response.
            StreamReader sReader = new StreamReader(response.GetResponseStream());

            //Gets the response and writes it to a string.
            string jsonResponse = sReader.ReadToEnd();

            //Write the response string into the ExchangeRate object.
            ExchangeRate info = JsonUtility.FromJson<ExchangeRate>(jsonResponse);
            return info;
        }
		catch (Exception)
		{
            //TODO: Add logging system
            return null;
        }
    }
}
