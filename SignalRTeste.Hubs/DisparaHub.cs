using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTeste.Hubs
{
    public class DisparaHub
    {

        public static void dispara(string message)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<Hubs.TesteHub>();
            hubContext.Clients.All.MessageReciever("admin@pica.all", DateTime.Now.ToString("HH:mm:ss") + "-" + message);
        }

    }
}
