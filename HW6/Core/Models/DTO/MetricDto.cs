using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models.DTO
{
   public abstract class MetricDto
    {
        [JsonPropertyName("ID")]
        public int ID { get; set; }
        [JsonPropertyName("Value")]
        public int Value { get; set; }
        [JsonPropertyName("Time")]
        public long Time { get; set; }

    }    
}
