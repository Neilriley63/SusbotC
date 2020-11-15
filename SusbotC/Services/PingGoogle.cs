using System;
using System.Net.NetworkInformation;
using System.Timers;

namespace SusbotC.Services
{
    public class PingGoogle
    {
        private string _remoteHostAddress;
        private Timer _pingTimer;
        private Ping _ping;

        public PingGoogle(string remoteHostAddress)
        {
            this._remoteHostAddress = remoteHostAddress;

            // Configure a Timer for use
            this._pingTimer = new Timer();
            this._pingTimer.Interval = 1000 * 50;
            this._pingTimer.Elapsed += new ElapsedEventHandler(this.TimeElapsed);
            this._pingTimer.Enabled = true;

            this._ping = new Ping();

        }

        private void PingRemoteHost()
        {

            try
            {
                PingReply reply = this._ping.Send(this._remoteHostAddress, 3000);

                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("Ping successful");
                }
                else
                {
                    Console.WriteLine("Ping failed");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private void TimeElapsed(Object sender, ElapsedEventArgs eventArgs)
        {
            PingRemoteHost();
        }

    }

}
