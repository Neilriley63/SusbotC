using System;


namespace SusbotCCore
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                new SusbotC().MainAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
