using System;
namespace Common.Models
{
    public class AttendeeModel
    {
        public AttendeeModel()
        {
        }

		public string type { get; set; }
		public StatusModel status { get; set; }
		public EmailModel emailAddress { get; set; }
    }
}
