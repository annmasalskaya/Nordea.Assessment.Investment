using System;

namespace Nordea.Assessment.Investment.Models
{
    /// <summary>
    /// Represents amount of certain product that was present in client's portfolio at certain date
    /// </summary>
    public class Position
    {
        public int PositionId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string ProductKey { get; set; }
    }
}