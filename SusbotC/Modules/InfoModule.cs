using Discord.Commands;
using System.Threading.Tasks;

namespace SusbotC.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {

        
        // ~say hello world -> hello world
        [Command("sus")]
        [Summary("Declares someone as sus.")]
        public Task SayAsync([Remainder][Summary("Person who is sus")] string susPerson)
            => ReplyAsync(susPerson);


        // ReplyAsync is a method on ModuleBase 
    }
}
