using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Common.Models
{
    public class MeModel
    {
        [JsonProperty("@odata.context")]
		public string context { get; set; }
		public string id { get; set; }
		public IList<string> businessPhones { get; set; }
		public string displayName { get; set; }
		public string givenName { get; set; }
		public string jobTitle { get; set; }
		public string mail { get; set; }
		public object mobilePhone { get; set; }
		public string officeLocation { get; set; }
		public object preferredLanguage { get; set; }
		public string surname { get; set; }
		public string userPrincipalName { get; set; }
    }
}
