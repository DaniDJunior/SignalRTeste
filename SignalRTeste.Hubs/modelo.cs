using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTeste.Hubs
{
    public class modelo
    {
        string nome { get; set; }

        string message { get; set; }

        public modelo ()
        {
            nome = string.Empty;
            message = string.Empty;
        }

        public modelo(string _nome, string _message)
        {
            nome = _nome;
            message = DateTime.Now.ToString("HH:mm:ss") + "-" + _message;
        }

    }
}
