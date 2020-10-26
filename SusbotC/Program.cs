using System;


namespace SusbotCCore
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                new SusbotC().StartAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
