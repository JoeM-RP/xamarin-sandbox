using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sandbox.Models
{
    public class GraphResponseModel<T> where T : GraphValueBaseModel
    {
        public GraphResponseModel()
        {
        }

		public IList<T> value { get; set; }

		[JsonProperty("@odata.context")]
		public string Context { get; set; }
    }
}
