namespace MilitaryElite
{
    public class Missions : IMissions
    {
        public Missions(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; set; }
        public State State { get; set; }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}