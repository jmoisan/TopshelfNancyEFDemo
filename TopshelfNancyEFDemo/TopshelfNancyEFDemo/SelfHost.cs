using System;
using Nancy.Hosting.Self;

namespace TopshelfNancyEFDemo
{
    class SelfHost
    {
        private NancyHost Host;

        public void Start()
        {
            var hostConfig = new HostConfiguration
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };

            Host = new NancyHost(hostConfig, new Uri("http://localhost:1234"));
            Host.Start();
        }

        public void Stop()
        {
            Host.Stop();
        }

    }
}
