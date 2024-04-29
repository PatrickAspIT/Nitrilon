namespace Nitrilon.Entities
{
    public class Member
    {

        #region Fields
        private int memberId;
        private string name;
        private string phoneNumber;
        private string email;
        private DateTime date;
        private int membershipId;
        #endregion

        #region Constructors
        public Member(int memberId, string name, string phoneNumber, string email, DateTime date, int membershipId)
        {
            MemberId = memberId;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Date = date;
            MembershipId = membershipId;
        }
        #endregion

        #region Properties
        public int MemberId { get => memberId; set => memberId = value; }
        public string Name { get => name; set => name = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Date { get => date; set => date = value; }
        public int MembershipId { get => membershipId; set => membershipId = value; } 
        #endregion

    }
}
