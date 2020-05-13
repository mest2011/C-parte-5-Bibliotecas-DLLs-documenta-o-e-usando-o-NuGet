using ByteBank.Modelos.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Estagiario : Funcionario
    {
        public Estagiario(double salario, string cpf) : base(salario, cpf)
        {

        }
        public override void AumentarSalario()
        {
            Salario *= 1;
        }

        protected override double GetBonificacao()
        {
            return 0;
        }
    }
}
