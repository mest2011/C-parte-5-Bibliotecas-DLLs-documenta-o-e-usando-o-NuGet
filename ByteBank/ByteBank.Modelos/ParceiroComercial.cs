using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class ParceiroComercial : IAutenticavel
    {
        AutenticadorHelper autenticador = new AutenticadorHelper();
        public string Senha { get; set; }

        public bool Autenticar(string senha)
        {
            return autenticador.CompararSenhas(Senha, senha);
        }
    }
}