using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace SusbotC.Modules
{
    public class ConjureModule : ModuleBase<SocketCommandContext>
    {


        // ~say hello world -> hello world
        [Command("conjure")]
        [Summary("Conjures a random animal from 5e.")]
        public Task SayAsync([Remainder][Summary("Number of animals to conjure")] string numberOfAnimals)
            => ReplyAsync(ConjureAnimals(numberOfAnimals));


        private static string ConjureAnimals(string numberOfAnimals)
        {
            string animalConjured = null;
            string[] oneConjuredAnimal = {
                "Allosaurus",
                "Aurochs",
                "Cave Bear",
                "Giant Boar",
                "Giant Constrictor Snake",
                "Giant Elk",
                "Hunter Shark",
                "Plesiosaurus",
                "Polar Bear",
                "Quetzalcoatlus",
                "Rhinoceros",
                "Saber-toothed Tiger",
                "Swarm of Poisonous Snakes"
            };
            string[] twoConjuredAnimals = {
                "Brown Bears",
                "Deinonychus",
                "Dire Wolves",
                "Giant Eagles",
                "Giant Hyenas",
                "Giant Octopodes",
                "Giant Spiders",
                "Giant Toads",
                "Giant Vultures",
                "Lions",
                "Swarms of Quippers",
                "Tigers"
            };
            string[] fourConjuredAnimals = {
                "Apes",
                "Black Bears",
                "Crocodiles",
                "Giant Goats",
                "Giant Sea Horses",
                "Giant Wasps",
                "Reef Sharks",
                "Swarms of Insects",
                "Swarms of Rot Grubs",
                "Warhorses"
            };
            string[] eightConjuredAnimals = {
                "Axe Beaks",
                "Boars",
                "Constrictor Snakes",
                "Cows",
                "Deep Rothes",
                "Dimetrodons",
                "Draft Horses",
                "Elks",
                "Giant Badgers",
                "Giant Bats",
                "Giant Centipedes",
                "Giant Frogs",
                "Giant Lizards",
                "Giant Owls",
                "Giant Poisonous Snakes",
                "Giant Wolf Spiders",
                "Hadrosauruses",
                "Oxen",
                "Panthers",
                "Pteranodons",
                "Riding Horses",
                "Rothes",
                "Stench Kows",
                "Swarms of Bats",
                "Swarms of Rats",
                "Swarms of Ravens",
                "Velociraptors",
                "Wolves"
            };

            switch (numberOfAnimals)
            {
                case "1":
                    animalConjured = "You have conjured one " + oneConjuredAnimal[new Random().Next(0, oneConjuredAnimal.Length)] + "!";
                    break;
                case "2":
                    animalConjured = "You have conjured two " + twoConjuredAnimals[new Random().Next(0, twoConjuredAnimals.Length)] + "!";
                    break;
                case "4":
                    animalConjured = "You have conjured four " + fourConjuredAnimals[new Random().Next(0, fourConjuredAnimals.Length)] + "!";
                    break;
                case "8":
                    animalConjured = "You have conjured eight " + eightConjuredAnimals[new Random().Next(0, eightConjuredAnimals.Length)] + "!";
                    break;
                default:
                    animalConjured = "Invalid selection, please choose either 1, 2, 4, or 8 conjured animals";
                    break;
            }

            return animalConjured;
        }
    }

}
