using System;
using Newtonsoft.Json;

namespace Common.Models
{
    public class GraphValueBaseModel
    {
        public GraphValueBaseModel()
        {
        }

		[JsonProperty("@odata.context")]
		public string Context { get; set; }
    }
}
