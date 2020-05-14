using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    class ClasseTeste
    {
        ClasseTeste() 
        {
            ModificadoresTeste teste = new ModificadoresTeste();
            teste.MetodoPublico();
            //teste.MetodoPrivado();
        }
        
    }

    //Classe que herda "ModificadoresTeste" e por isso ela tem acesso ao "MetodoProtegido"
    class ClasseDerivada : ModificadoresTeste
    {
        public ClasseDerivada()
        {
            MetodoProtegido();
        }

    }

    public class ModificadoresTeste
    {
        public void MetodoPublico()
        {
            //Metodo visivel de qualquer classe e projeto
        }
        private void MetodoPrivado()
        {
            //Metodo visivel apenas dentro da mesma classe
        }
        protected void MetodoProtegido()
        {
            //Metodo visivel apenas dentro da mesma classe e classe derivadas
        }
        internal void MetodoInterno()
        {
            //Metodo visivel apenas dentro do mesmo projeto
        }
        internal protected void MetodoInternoProtegido()
        {
            //Metodo visivel apenas a
        }
    }
}
