using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team

    {
        private protected string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }
       
        public IReadOnlyList<Person> FirstTeam
        {
            get => this.firstTeam.AsReadOnly();
        
        }

        public IReadOnlyList<Person> ReserveTeam
        {
            get => this.reserveTeam.AsReadOnly();
      
        }


        public void AddPlayer(Person person)
        {
            if (person.Age <= 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }

        }
    }
}
