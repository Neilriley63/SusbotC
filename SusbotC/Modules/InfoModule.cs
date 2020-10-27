using Discord.Commands;
using System.Threading.Tasks;

namespace SusbotC.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {

        string info = "Hi! I'm the Susbot. I am written in C# by Neil Riley. My source code can be found at: https://github.com/Neilriley63/SusbotC. \nMy available commands are: !sus and !conjure.";

        // ~say hello world -> hello world
        [Command("susinfo")]
        [Summary("Reply with information about Susbot")]
        public Task SayAsync()
            => ReplyAsync(info);


        
    }

}
