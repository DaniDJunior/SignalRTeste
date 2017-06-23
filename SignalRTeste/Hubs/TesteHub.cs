using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRTeste.Hubs
{
    [HubName("teste")]
    public class TesteHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void CreateConnection(string nome)
        {
            if (CacheHelper.Exists("Client_" + nome))
            {
                Clients.Caller.MessageError("Usuario já existe");
            }
            else
            {
                CacheHelper.Add<string>(Context.ConnectionId, "Client_" + nome);
                Clients.Caller.ConnectionSucess("Chat conectado para " + nome);
            }
        }

        public void SendMessange(string nome, string message)
        {
            if (CacheHelper.Exists("Client_" + nome))
            {
                Clients.Client(CacheHelper.Get<string>("Client_" + nome)).MessageReciever(nome, DateTime.Now.ToString("HH:mm:ss") + "-" + message);
                Clients.Caller.MessageEco(DateTime.Now.ToString("HH:mm:ss") + "-" + message);
            }
            else
            {
                Clients.Caller.MessageError("Usuario não existe para mandar mensagem");
            }
        }

        public void BroadCastServerTime()
        {
            Clients.All.MessageReciever(DateTime.Now);
        }
    }
}