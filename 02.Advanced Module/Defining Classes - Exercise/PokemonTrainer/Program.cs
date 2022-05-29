using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input;
            var trainers = new Dictionary<string, Trainer>();
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] information = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                string trainer = information[0];
                string pokemonName = information[1];
                string pokemonElement = information[2];
                int pokemonHealth = int.Parse(information[3]);

                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer newTrainer = new Trainer(trainer);
                if (!trainers.ContainsKey(trainer))
                {
                    trainers.Add(trainer, new Trainer(trainer));
                }
                trainers[trainer].Pokemons.Add(currentPokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string pokemonElement = input;
                foreach (var trainersValue in trainers.Values)
                {
                    if (trainersValue.Pokemons.Any(x => x.Element == pokemonElement))
                    {
                        trainersValue.NumberOfBadges++;
                    }
                    else
                    {
                        trainersValue.Pokemons.ForEach(x => x.Health -= 10);
                        trainersValue.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }
            }
            //"{trainerName} {badges} {numberOfPokemon}"
            foreach (var trainer in trainers.OrderByDescending(x => x.Value.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.NumberOfBadges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
