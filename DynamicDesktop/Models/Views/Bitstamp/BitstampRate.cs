using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicDesktop.Models.Views.Bitstamp
{
    public class BitstampRate
    {
        [JsonProperty("high")]
        public decimal High { get; set; }

        [JsonProperty("last")]
        public decimal Last { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("bid")]
        public decimal Bid { get; set; }

        [JsonProperty("vwap")]
        public decimal Vwap { get; set; }

        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        [JsonProperty("low")]
        public decimal Low { get; set; }

        [JsonProperty("ask")]
        public decimal Ask { get; set; }

        [JsonProperty("open")]
        public decimal Open { get; set; }
    }
}
