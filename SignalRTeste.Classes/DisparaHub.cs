using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTeste.Classes
{
    public class DisparaHub
    {

        public static void dispara(string message)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<Hubs.TesteHub>();
            hubContext.Clients.All.MessageReciever("teste");
        }

    }
}
