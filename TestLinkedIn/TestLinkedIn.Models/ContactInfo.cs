namespace TestLinkedIn.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ContactInfo
    {
        [DisplayFormat(NullDisplayText = "No")]
        public string Phone { get; set; }

        [DisplayFormat(NullDisplayText = "No")]
        public string Twitter { get; set; }

        [DisplayFormat(NullDisplayText = "No")]
        public string Website { get; set; }

        [DisplayFormat(NullDisplayText = "No")]
        public string Facebook { get; set; }
    }
}
