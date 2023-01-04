namespace IdentityApp.Models
{
    public class Vacations
    {
        public int VacationsId { get; set; }

        public double CountOfVacationsDay { get; set; }

        public string VacationsMonth { get; set; }


        public string VacationsOwner { get; set; }

        public string CreatorId { get; set; }

        public VacationsStatus Status { get; set; }
    }
}

namespace IdentityApp
{
    public enum VacationsStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}