using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _03._MOBA_Challenger
{

    class Program
    {
        static void Main(string[] args)
        {
            var dataPlayer = new Dictionary<string, Dictionary<string, int>>();
            var totalSkillPlayer = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Season end")
                {
                    break;
                }

                //player and his position and skill
                if (input.Contains(" -> "))
                {
                    string[] data = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string name = data[0];
                    string position = data[1];
                    int skillPoints = int.Parse(data[2]);

                    //player and his position and skill
                    if (!dataPlayer.ContainsKey(name))
                    {
                        dataPlayer.Add(name, new Dictionary<string, int>());
                        dataPlayer[name].Add(position, skillPoints);
                        totalSkillPlayer.Add(name, skillPoints);
                    }
                    else
                    {
                        if (dataPlayer[name].ContainsKey(position))
                        {
                            if (dataPlayer[name][position] < skillPoints)
                            {
                                dataPlayer[name][position] = skillPoints;
                                totalSkillPlayer[name] = skillPoints;
                            }
                        }
                        else
                        {
                            dataPlayer[name].Add(position, skillPoints);
                            totalSkillPlayer[name] += skillPoints;
                        }
                    }
                }
                //player vs player - fight
                else
                {
                    string[] data = input.Split(" vs ", StringSplitOptions.RemoveEmptyEntries);
                    string firstPlayer = data[0];
                    string secondPlayer = data[1];

                    if (dataPlayer.ContainsKey(firstPlayer) && dataPlayer.ContainsKey(secondPlayer))
                    {
                        bool flag = false;
                        foreach (var firstPosition in dataPlayer[firstPlayer])
                        {
                            foreach (var secondPosition in dataPlayer[secondPlayer])
                            {
                                if (firstPosition.Key == secondPosition.Key)
                                {
                                    if (firstPosition.Value > secondPosition.Value)
                                    {
                                        flag = true;
                                        dataPlayer.Remove(secondPlayer);
                                        totalSkillPlayer.Remove(secondPlayer);
                                    }
                                    else if (firstPosition.Value < secondPosition.Value)
                                    {
                                        flag = true;
                                        totalSkillPlayer.Remove(firstPlayer);
                                        dataPlayer.Remove(firstPlayer);
                                    }
                                    else
                                    {
                                        flag = true;
                                        continue;
                                    }
                                }
                            }

                            if (flag)
                            {
                                break;
                            }
                        }
                    }

                }
            }

            foreach (var players in totalSkillPlayer
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{players.Key}: {players.Value} skill");
                foreach (var d in dataPlayer[players.Key].OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {d.Key} <::> {d.Value}");
                }
            }
        }
    }
}
