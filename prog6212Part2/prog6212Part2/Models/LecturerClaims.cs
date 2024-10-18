namespace prog6212Part2.Models
{
    public class LecturerClaims
    {
        public int claimID { get; set; }
        public string claimLecturerName { get; set; } // Fixed required property syntax
        public int claimHourlyRate { get; set; }
        public int claimHoursWorked { get; set; }
        public string claimAdditionalNotes { get; set; }
        public string claimFileName { get; set; } // Fixed required property syntax
        public DateTime claimDate { get; set; }
    }
}
