using System;
using Newtonsoft.Json;

namespace Sandbox.Models
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
