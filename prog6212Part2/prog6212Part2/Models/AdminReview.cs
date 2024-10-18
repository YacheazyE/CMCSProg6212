namespace prog6212Part2.Models
{
    public class AdminReview
    {
        public bool reviewStatus = false;

        public int claimID { get; set; }

        public string LecturerName { get; set; }

        public DateTime claimDate { get; set; }
    }
}
