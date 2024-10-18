namespace prog6212Part2.Models
{
    public class LecturerClaims
    {
        public int claimID { get; set; }
        public string claimLecturerName { get; set; } 
        public int claimHourlyRate { get; set; }
        public int claimHoursWorked { get; set; }
        public string claimAdditionalNotes { get; set; }
        public string claimFileName { get; set; } 
        public DateTime claimDate { get; set; }

        public bool claimStatus { get; set; }
    }
}
