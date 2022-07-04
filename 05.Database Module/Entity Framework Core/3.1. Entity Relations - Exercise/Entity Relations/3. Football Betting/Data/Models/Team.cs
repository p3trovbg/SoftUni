namespace P03_FootballBetting.Data.Models 
{
    public class Team
    {
        //•	Team – TeamId, Name, LogoUrl, Initials (JUV, LIV, ARS…),
        //Budget, PrimaryKitColorId, SecondaryKitColorId, TownId
        public int TeamId { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public Initials Initials { get; set; }

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }

        public int SecondaryKitColorId { get; set; }

        public int TownId { get; set; }
    }
}
