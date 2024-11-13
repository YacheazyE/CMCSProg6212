namespace prog6212Part2.Models
{
    public class LecturerClaims
    {
        // Unique identifier for each claim
        public int claimID { get; set; }

        // Name of the lecturer submitting the claim
        public string claimLecturerName { get; set; }

        // Lecturer's hourly rate
        public int claimHourlyRate { get; set; }

        // Number of hours worked for the claim
        public int claimHoursWorked { get; set; }

        // Additional notes provided by the lecturer (optional)
        public string claimAdditionalNotes { get; set; }

        // File name of the uploaded claim document
        public string claimFileName { get; set; }

        // Date when the claim was submitted
        public DateTime claimDate { get; set; }

        // Status of the claim (e.g., approved or rejected)
        public Boolean claimStatus { get; set; }
    }
}

