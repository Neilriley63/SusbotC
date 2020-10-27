using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace SusbotC.Modules
{
    public class SusModule : ModuleBase<SocketCommandContext>
    {

        
        // ~say hello world -> hello world
        [Command("sus")]
        [Summary("Declares someone as sus.")]
        public Task SayAsync([Remainder][Summary("Person who is sus")] string susPerson)
            => ReplyAsync(SusPerson(susPerson));


        private static string SusPerson(string susPerson)
        {
            string susFinal = null;
            string[] susSayings = { 
                susPerson + " kinda sus ngl",
                susPerson + " is pretty sus",
                susPerson + " sus",
                "I think " + susPerson + " is sus",
                "hella sus on " + susPerson
            };

            int rand = new Random().Next(0, susSayings.Length);

            if(susPerson != "help")
            {
                susFinal = susSayings[rand];
            }
            else
            {
                susFinal = "Declare someone sus with the !sus command!\nJust type !sus <name> and the named person will be declared as sus.";
            }
            
            
            return susFinal;
        }
    }

}
