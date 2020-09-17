using System;

namespace Assets.Scripts.Data
{
    /// <summary>
    /// Serializable class that contains fields for json response from API.
    /// Fields are case-sensitive with Unity's JsonUtility.
    /// </summary>
    [Serializable]
    public class RatesResult
    {
        public double CNY;
        public double USD;
    }
}
