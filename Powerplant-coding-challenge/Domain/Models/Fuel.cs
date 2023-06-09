﻿using System.Text.Json.Serialization;

namespace Powerplant_coding_challenge.Domain.Models
{
    public class Fuel
    {
        [JsonPropertyName("gas(euro/MWh)")]
        public double Gas { get; set; }

        [JsonPropertyName("kerosine(euro/MWh)")]
        public double Kerosine { get; set; }

        [JsonPropertyName("co2(euro/ton)")]
        public double Co2 { get; set; }

        [JsonPropertyName("wind(%)")]
        public double Wind { get; set; }
    }

}
