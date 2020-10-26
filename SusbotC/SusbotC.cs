using System.Threading.Tasks;
using SusbotC.Services;

namespace SusbotCCore
{
    public class SusbotC
    {
        private StartupService startup;

        public async Task MainAsync()
        {
            startup = new StartupService();
            await startup.StartupServiceAsync();
            
        }


    }

}
