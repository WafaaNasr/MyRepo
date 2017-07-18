namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        public string Name { get; set; }
        public short SignUpFree { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte Unkown = 0;// Readonly to prevent modifying the values anywhere in the project
        public static readonly byte PayAsYouGo = 1;
    }
}