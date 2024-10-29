namespace AuthenCard.Models
{
    public class ClaimCheck
    {
        public string claimType { get; set; }
        public string claimCode { get; set; }
        public string hcode { get; set; }
        public DateTime claimDateTime { get; set; }
        public DateTime checkDate { get; set; }
    }

}