using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace SignalRTeste.App_Start
{
    public class Service
    {
        private int delay;

        public Service()
        {
            delay = 30000;
        }

        public void Start(int delay)
        {
            Thread t = new Thread(OnLoop);
            t.Start();
        }

        protected void OnLoop()
        {
            while (true)
            {
                DateTime dateStart = DateTime.Now;
                Loop();
                Thread.Sleep(delay - (DateTime.Now - dateStart).Milliseconds);
            }
        }

        protected void Loop()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<Hubs.TesteHub>();
            context.Clients.All.MessageReciever("Server", "PING");
        }
    }
}