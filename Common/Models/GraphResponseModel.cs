using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Common.Models
{
    public class GraphResponseModel<T> where T : GraphValueBaseModel
    {
        public GraphResponseModel()
        {
        }

		public IList<T> Value { get; set; }

		[JsonProperty("@odata.context")]
		public string Context { get; set; }
    }
}
