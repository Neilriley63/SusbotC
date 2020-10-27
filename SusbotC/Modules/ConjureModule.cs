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
                "Allosaurus (https://bit.ly/31Gmltd)",
                "Aurochs (https://bit.ly/3dXQtVT)",
                "Cave Bear (https://bit.ly/31L8CkQ)",
                "Giant Boar (https://bit.ly/34tvreE)",
                "Giant Constrictor Snake (https://bit.ly/3oFdUIy)",
                "Giant Elk (https://bit.ly/35G2745)",
                "Hunter Shark (https://bit.ly/37JoCHZ)",
                "Plesiosaurus(https://bit.ly/2HDrpYj)",
                "Polar Bear (https://bit.ly/34w1b2H)",
                "Quetzalcoatlus (https://bit.ly/2ToS0uJ)",
                "Rhinoceros (https://bit.ly/3kxC7hq)",
                "Saber-toothed Tiger (https://bit.ly/37PnGSt)",
                "Swarm of Poisonous Snakes (https://bit.ly/37K6gGw)"
            };
            string[] twoConjuredAnimals = {
                "Brown Bears (https://bit.ly/3mmF1WP)",
                "Deinonychus (https://bit.ly/3mjDOPU)",
                "Dire Wolves (https://bit.ly/2TtlpE0)",
                "Giant Eagles (https://bit.ly/3jB4pWN)",
                "Giant Hyenas (https://bit.ly/3ouC8VL)",
                "Giant Octopodes (https://bit.ly/34tCe7Y)",
                "Giant Spiders (https://bit.ly/3jxxGSc)",
                "Giant Toads (https://bit.ly/3dWrLoQ)",
                "Giant Vultures (https://bit.ly/3mrxTbD)",
                "Lions (https://bit.ly/2G162zs)",
                "Swarms of Quippers (https://bit.ly/35AEeea)",
                "Tigers (https://bit.ly/2J4bJ0B)"
            };
            string[] fourConjuredAnimals = {
                "Apes (https://bit.ly/34t8Lep)",
                "Black Bears (https://bit.ly/3jt9osR)",
                "Crocodiles (https://bit.ly/2TFAAKx)",
                "Giant Goats (https://bit.ly/3jwRQMn)",
                "Giant Sea Horses (https://bit.ly/3oyuJF4)",
                "Giant Wasps (https://bit.ly/37K9BFy)",
                "Reef Sharks (https://bit.ly/35G6mwx)",
                "Swarms of Insects (https://bit.ly/35BG91Z)",
                "Swarms of Rot Grubs (https://bit.ly/3dY9W8K)",
                "Warhorses (https://bit.ly/2Ts6HwV)"
            };
            string[] eightConjuredAnimals = {
                "Axe Beaks (https://bit.ly/37GEOtq)",
                "Boars (https://bit.ly/34tyTWE)",
                "Constrictor Snakes (https://bit.ly/2Tu33CE)",
                "Cows (https://bit.ly/37WALth)",
                "Deep Rothes (https://bit.ly/37InWm0)",
                "Dimetrodons (https://bit.ly/3jvOfy0)",
                "Draft Horses (https://bit.ly/3jxb0BM)",
                "Elks (https://bit.ly/3mjHCka)",
                "Giant Badgers (https://bit.ly/31LfxdX)",
                "Giant Bats (https://bit.ly/31IxVEg)",
                "Giant Centipedes (https://bit.ly/35z3wta)",
                "Giant Frogs (https://bit.ly/3jzWJUO)",
                "Giant Lizards (https://bit.ly/2TsldVw)",
                "Giant Owls (https://bit.ly/3otsDWT)",
                "Giant Poisonous Snakes (https://bit.ly/2HtoYry)",
                "Giant Wolf Spiders (https://bit.ly/31ILCmk)",
                "Hadrosauruses (https://bit.ly/2J9KL81)",
                "Oxen (https://bit.ly/2HzSTho)",
                "Panthers (https://bit.ly/35zvZ1O)",
                "Pteranodons (https://bit.ly/35FekFQ)",
                "Riding Horses (https://bit.ly/2FZNu2u)",
                "Rothes (https://bit.ly/37InWm0)",
                "Stench Kows (https://bit.ly/2HDi5np)",
                "Swarms of Bats (https://bit.ly/3jxvoCX)",
                "Swarms of Rats (https://bit.ly/2JaVyyM)",
                "Swarms of Ravens (https://bit.ly/35zJLlb)",
                "Velociraptors (https://bit.ly/2HHZI04)",
                "Wolves (https://bit.ly/37HOunl)"
            };

            switch (numberOfAnimals)
            {
                case "1":
                    animalConjured = "You have conjured one " + oneConjuredAnimal[new Random().Next(0, oneConjuredAnimal.Length)];
                    break;
                case "2":
                    animalConjured = "You have conjured two " + twoConjuredAnimals[new Random().Next(0, twoConjuredAnimals.Length)];
                    break;
                case "4":
                    animalConjured = "You have conjured four " + fourConjuredAnimals[new Random().Next(0, fourConjuredAnimals.Length)];
                    break;
                case "8":
                    animalConjured = "You have conjured eight " + eightConjuredAnimals[new Random().Next(0, eightConjuredAnimals.Length)];
                    break;
                case "dan":
                    animalConjured = "You have conjured Dan, fuck that guy";
                    break;
                case "help":
                    animalConjured = "This command generated a random conjured animal based on the Conjure Animal spell. The available options are:\n(1) for one CR2 beast\n(2) for two CR1 beasts\n(4) for four CR1/2 beasts\n(8) for eight CR1/4 beasts";
                    break;
                default:
                    animalConjured = "Invalid selection, please choose either 1, 2, 4, or 8 conjured animals";
                    break;
            }

            int danStop = new Random().Next(20);
            if (danStop == 13)
            {
                animalConjured = "Stop it, Dan.";
            }
            return animalConjured;
        }
    }

}
