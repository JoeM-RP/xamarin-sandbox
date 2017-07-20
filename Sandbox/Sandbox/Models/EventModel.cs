using System;
using System.Collections.Generic;

namespace Sandbox.Models
{
    public class EventModel : GraphValueBaseModel
    {
        public EventModel()
        {
        }

        public string id { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime lastModifiedDateTime { get; set; }
        public string changeKey { get; set; }
        public IList<object> categories { get; set; }
        public string originalStartTimeZone { get; set; }
        public string originalEndTimeZone { get; set; }
        public string iCalUId { get; set; }
        public int reminderMinutesBeforeStart { get; set; }
        public bool isReminderOn { get; set; }
        public bool hasAttachments { get; set; }
        public string subject { get; set; }
        public string bodyPreview { get; set; }
        public string importance { get; set; }
        public string sensitivity { get; set; }
        public bool isAllDay { get; set; }
        public bool isCancelled { get; set; }
        public bool isOrganizer { get; set; }
        public bool responseRequested { get; set; }
        public object seriesMasterId { get; set; }
        public string showAs { get; set; }
        public string type { get; set; }
        public string webLink { get; set; }
        public string onlineMeetingUrl { get; set; }
        public ResponseModel responseStatus { get; set; }
        //public Body body { get; set; }
        public TimeModel start { get; set; }
        public TimeModel end { get; set; }
        public LocationModel location { get; set; }
        public object recurrence { get; set; }
        public IList<AttendeeModel> attendees { get; set; }
        public OrganizerModel organizer { get; set; }
    }
}
