using System;

namespace Nordea.Assessment.Investment.Models
{
    /// <summary>
    /// Market price of certain product at certain date
    /// </summary>
    public class Price
    {
        public DateTime Date { get; set; }
        public string ProductKey { get; set; }
        public double Value { get; set; }
    }

}