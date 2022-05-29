using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            var soldiers = new Dictionary<int, ISoldier>();
            
            decimal salary = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split();
                string typeSoldier = info[0];
                int id = int.Parse(info[1]);
                string firstName = info[2];
                string lastName = info[3];
                if(typeSoldier != "Spy")
                {
                     salary = decimal.Parse(info[4]);
                }
                switch (typeSoldier)
                {
                    case "Private":                      
                        soldiers.Add(id, new Private(id, firstName, lastName, salary));
                        break;
                    case "LieutenantGeneral":
                        ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
                        for (int i = 5; i < info.Length; i++)
                        {
                            IPrivate soldier = soldiers[int.Parse(info[i])] as IPrivate;
                            lieutenantGeneral.Privates.Add(soldier);
                        }
                        soldiers.Add(id, lieutenantGeneral);
                        
                        break;
                    case "Engineer":
                        string corp = info[5];
                        bool isCorp = Enum.TryParse<Corps>(corp, out Corps result);
                        if (!isCorp)
                        {
                            continue;
                        }
                        IEngineer engineer = new Engineer(id, firstName,lastName, salary, result);
                        for (int i = 6; i < info.Length; i+= 2)
                        {
                            string partName = info[i];
                            int hours = int.Parse(info[i + 1]);
                            engineer.Repairs.Add(new Repair(partName, hours));
                        }
                        soldiers.Add(id, engineer);
                        break;
                    case "Commando":
                        string currentCorp = info[5];
                        bool isCorps = Enum.TryParse<Corps>(currentCorp, out Corps res);
                        if (!isCorps)
                        {
                            continue;
                        }
                        ICommando commando = new Commando(id, firstName, lastName, salary, res);
                        for (int i = 6; i < info.Length; i+= 2)
                        {
                            string missionCode = info[i];
                            string missionState = info[i + 1];
                            bool isValid = Enum.TryParse<State>(missionState, out State state);
                            if (!isValid)
                            {
                                continue;
                            }
                            IMissions mission = new Missions(missionCode, state);
                            commando.Missions.Add(mission);
                        }
                        soldiers.Add(id, commando);
                        break;
                    case "Spy":
                        int codeNumber = int.Parse(info[4]);
                        ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                        soldiers.Add(id, spy);
                        break;
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.Value.ToString());
            }
        }
    } 
}
